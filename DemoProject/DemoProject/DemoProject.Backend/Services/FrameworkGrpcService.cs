using DemoProject.Backend.Repositories;
using DemoProject.Shared;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoProject.Backend.Services
{
	public class FrameworkGrpcService : FrameworkService.FrameworkServiceBase
	{
		IFrameworkRepository frameworkRepository;
		public FrameworkGrpcService(IFrameworkRepository frameworkRepository)
		{
			this.frameworkRepository = frameworkRepository;
		}

		public async override Task<QueryReply> Query(Empty request, ServerCallContext context)
		{
			var frameworks = await frameworkRepository.Query();

			var reply = new QueryReply();
			reply.Frameworks.AddRange(frameworks.Select(x => new Framework()
			{
				Id = x.Id,
				Name = x.Name,
				Logo = x.Logo,
				Grade = x.Grade
			}));
			return reply;
		}

		public async override Task<AddReply> Add(AddRequest request, ServerCallContext context)
		{
			var frameworkEntity = new FrameworkModel()
			{
				Name = request.Framework.Name,
				Logo = request.Framework.Logo,
				Grade = request.Framework.Grade,
			};

			await frameworkRepository.Add(frameworkEntity);

			return new AddReply()
			{
				UpdatedFramework = new Framework()
				{
					Id = frameworkEntity.Id,
					Name = frameworkEntity.Name,
					Logo = frameworkEntity.Logo,
					Grade = frameworkEntity.Grade
				}
			};
		}
	}
}
