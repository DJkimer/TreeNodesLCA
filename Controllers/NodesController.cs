using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TreesAPI.Data;
using TreesAPI.Dtos;
using TreesAPI.Models;

namespace TreesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        private readonly INodeRepository _repo;
        private readonly IMapper _mapper;
        public NodesController(INodeRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // GET api/nodes
        [HttpGet]
        public async Task<IActionResult> GetNodes()
        {
            var nodes = await _repo.GetNodes();
            return Ok(nodes);
        }

        // GET api/nodes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNode(int id)
        {
            var node = await _repo.GetNode(id);
            var nodeForReturn = _mapper.Map<NodeForReturnDto>(node);
            return Ok(node);
        }

        [HttpGet("LCA/{valueFirstNode}/{valueSecondNode}")]
        public async Task<IActionResult> GetLCA(int valueFirstNode,int valueSecondNode )
        {
            var nodeRoot = await _repo.GetFisrtNode();
            var nodeFirst = await _repo.GetNodeByValue(valueFirstNode);
            var nodeSecond = await _repo.GetNodeByValue(valueSecondNode);
            if(nodeFirst != null && nodeSecond != null)
            {
                var nodeAncestor = LowestCommonAncestor(nodeFirst, nodeFirst, nodeSecond);
                if(nodeAncestor != null)
                    return Ok(nodeAncestor);
            }
            return BadRequest("Node Ancestor don't found");
        }

        // POST api/nodes
        [HttpPost("insert/{value}")]
        public async Task<IActionResult> Post(int value)
        {
            var nodeFirst = await _repo.GetFisrtNode();
            var nodeNew = InsertNode(nodeFirst,value);
            await _repo.SaveAll();
            return Ok();
        }

        private Node InsertNode(Node nodeFirst, int value)
        {
            NodeForCreationDto nodeForCreation = new NodeForCreationDto{
                    Value = value
                };
            var node = _mapper.Map<Node>(nodeForCreation);
            if (nodeFirst == null)
            {
                _repo.Add(node);
                return (node);
            }
            InsertNodeRecursive(nodeFirst, node);
            return (node);
        }
        private void InsertNodeRecursive(Node nodeFirst, Node newNode)
        {
            if (nodeFirst == null)
                nodeFirst = newNode;
 
            if (newNode.Value < nodeFirst.Value)
            {
                if (nodeFirst.Left == null)
                    nodeFirst.Left = newNode;
                else
                    InsertNodeRecursive(nodeFirst.Left, newNode);
 
            }
            else
            {
                if (nodeFirst.Right == null)
                    nodeFirst.Right = newNode;
                else
                    InsertNodeRecursive(nodeFirst.Right, newNode);
            }
            _repo.SaveAll();
        }

        public Node LowestCommonAncestor(Node nodeFirst, Node p, Node q)
        {
            var node = LowestCommonAncestorHelper(nodeFirst, p, q);
            if (node == null)
                return null;
            bool foundSecondNode = false;
            if (node == p) 
            {
                foundSecondNode = treeTraverse(nodeFirst, q); 
            }
            else
                foundSecondNode = treeTraverse(nodeFirst, p);
            if (foundSecondNode)
                return node;
            else
                return null;
        }

        private bool treeTraverse(Node nodeFirst, Node node)
        {
            if (nodeFirst == null)
                return false;
            if (nodeFirst == node)
                return true;

            return treeTraverse(nodeFirst.Left, node) || treeTraverse(nodeFirst.Right, node);
        }

        
        private Node LowestCommonAncestorHelper(Node nodeFirst, Node p, Node q)
        {		    
            if (nodeFirst == null || nodeFirst == p || nodeFirst == q)
                return nodeFirst;

            // post order traversal
            var left  = LowestCommonAncestorHelper(nodeFirst.Left, p, q);
            var right = LowestCommonAncestorHelper(nodeFirst.Right, p, q);

            if (left != null && right != null)
            {
                return nodeFirst;
            }

            if (left != null)
                return left;
            else if (right != null)
                return right;
            else
                return null;
        }

    }
}