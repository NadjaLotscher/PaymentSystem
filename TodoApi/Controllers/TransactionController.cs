﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentSystem;
using PaymentSystem.Models;
using WebApi.Extension;
using WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly SystemContext _context;

        public TransactionController(SystemContext context)
        {
            _context = context;
        }

        // GET: api/Transaction/{Username}
        [HttpGet("{Username}")]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetAllTransaction(string Username)
        {
            // Get the student with the matching username 
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Username == Username);

            if (student == null)
            {
                return NotFound();
            }

            // Get transactions for the found student
            var transactions = await _context.Transactions.Where(t => t.Student.StudentId == student.StudentId).ToListAsync();

            // Convert transactions to DTOs
            var transactionDTOs = transactions.Select(t => t.ToModel()).ToList();

            return Ok(transactionDTOs);
        }


        // POST: api/Transaction
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(TransactionDTO transactionDTO)
        {
            Transaction transaction = transactionDTO.ToDAL();

            using (var transactionScope = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.Transactions.Add(transaction);
                    await _context.SaveChangesAsync();

                    // Commit transaction
                    await transactionScope.CommitAsync();

                    // Convert back to DTO to return
                    var transactionToReturn = transaction.ToModel();

                    return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId }, transactionToReturn);
                }
                catch (Exception)
                {
                    await transactionScope.RollbackAsync();
                    throw;
                }
            }
        }

        // GET: api/Transaction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDTO>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            var transactionDTO = transaction.ToModel();
            return Ok(transactionDTO);
        }

        // POST: api/Transaction/PostTransaction (Addming Money)
        [HttpPost("PostTransaction")]
        public async Task<IActionResult> PostTransaction(TransactionRequestDTO transactionRequest)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Username == transactionRequest.Username);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            student.Balance += transactionRequest.Amount;

            var transaction = new Transaction
            {
                StudentId = student.StudentId,
                Amount = transactionRequest.Amount,
                TransactionDate = DateTime.Now,
                TransactionType = transactionRequest.TransactionType
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }


        // POST: api/Transaction/print (Print Request)
        [HttpPost("print")]
        public async Task<IActionResult> PostPrintRequest(PrintRequestDTO printRequest)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.Username == printRequest.Username);
            if (student == null)
            {
                return NotFound("Student not found");
            }

            decimal costPerCopy = 0.08M;
            decimal totalCost = printRequest.NumberOfCopies * costPerCopy;

            if (student.Balance < totalCost)
            {
                return BadRequest("Insufficient balance");
            }

            student.Balance -= totalCost;

            var transaction = new Transaction
            {
                StudentId = student.StudentId,
                Amount = totalCost,
                TransactionDate = DateTime.Now,
                TransactionType = "print"
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return Ok(transaction);
        }
    }
}
