using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanShare.Domain.Dtos;
public record CodeUserConnectionDto(string Code, Guid UserId);