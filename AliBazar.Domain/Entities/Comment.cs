﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliBazar.Domain.Entities;

public class Comment
{
    public long Id { get; set; }
    public Product Product { get; set; }
    public User User { get; set; }
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
    public string Commentaria { get; set; }
}
