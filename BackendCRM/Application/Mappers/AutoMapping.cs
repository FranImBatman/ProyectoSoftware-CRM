using Application.DTOs;
using Application.DTOs.Requests;
using Application.DTOs.Response;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<ProjectRequest, Projects>()
                .ForMember(p => p.ProjectName, pr => pr.MapFrom(pr => pr.Name))
                .ForMember(p => p.StartDate, pr => pr.MapFrom(pr => pr.StartDate))
                .ForMember(p => p.EndDate, pr => pr.MapFrom(pr => pr.EndDate))
                .ForMember(p => p.ClientID, pr => pr.MapFrom(pr => pr.Client))
                .ForMember(p => p.CampaignType, pr => pr.MapFrom(pr => pr.CampaignType))
                .ForMember(p => p.CreateDate, pr => pr.Ignore())
                .ForMember(p => p.UpdateDate, pr => pr.Ignore())
                .AfterMap((pr, p) =>
                {
                    p.CreateDate = DateTime.Now;
                });



            CreateMap<Projects, ProjectResponse>()
                .ForMember(prp => prp.Id, p => p.MapFrom(p => p.ProjectID))
                .ForMember(prp => prp.Name, p => p.MapFrom(p => p.ProjectName))
                .ForMember(prp => prp.StartDate, p => p.MapFrom(p => p.StartDate))
                .ForMember(prp => prp.EndDate, p => p.MapFrom(p => p.EndDate))
                .ForMember(prp => prp.Client, p => p.MapFrom(p => p.ClientsNavigator))
                .ForMember(prp => prp.CampaignType, p => p.MapFrom(p => p.CampaignTypesNavigator));
              

            CreateMap<Projects, ProjectDetails>()
                 .ForMember(pd => pd.Data, opt => opt.MapFrom(pr => pr))
                 .ForMember(pd => pd.Interactions, opt => opt.MapFrom(pr => pr.Interactions))
                 .ForMember(pd => pd.Tasks, opt => opt.MapFrom(p => p.Tasks));
                 
               

            CreateMap<ClientRequest, Clients>()
                .ForMember(c => c.Name, cr => cr.MapFrom(cr => cr.Name))
                .ForMember(c => c.Email, cr => cr.MapFrom(cr => cr.Email))
                .ForMember(c => c.Phone, cr => cr.MapFrom(cr => cr.Phone))
                .ForMember(c => c.Company, cr => cr.MapFrom(cr => cr.Company))
                .ForMember(c => c.Address, cr => cr.MapFrom(cr => cr.Address));

            CreateMap<Clients, ClientResponse>()
                .ForMember(crp => crp.Id, c => c.MapFrom(c => c.ClientID))
                .ForMember(crp => crp.Name, c => c.MapFrom(c => c.Name))
                .ForMember(crp => crp.Email, c => c.MapFrom(c => c.Email))
                .ForMember(crp => crp.Phone, c => c.MapFrom(c => c.Phone))
                .ForMember(crp => crp.Company, c => c.MapFrom(c => c.Company))
                .ForMember(crp => crp.Address, c => c.MapFrom(c => c.Address));




            CreateMap<TaskRequest, Tasks>()
                .ForMember(t => t.Name, tr => tr.MapFrom(tr => tr.Name))
                .ForMember(t => t.DueDate, tr => tr.MapFrom(tr => tr.DueDate))
                .ForMember(t => t.AssignedTo, tr => tr.MapFrom(tr => tr.AssignedTo))
                .ForMember(t => t.Status, tr => tr.MapFrom(tr => tr.Status))
                .AfterMap((tr, t) =>
                {
                    if(t.CreateDate == default)
                    {
                        t.CreateDate = DateTime.Now;
                    }
                });


            CreateMap<Tasks, TaskResponse>()
               .ForMember(trp => trp.Id, t => t.MapFrom(t => t.TaskID))
               .ForMember(trp => trp.Name, t => t.MapFrom(t => t.Name))
               .ForMember(trp => trp.DueDate, t => t.MapFrom(t => t.DueDate))
               .ForMember(trp => trp.Project, t => t.MapFrom(t => t.ProjectID))
               .ForMember(trp => trp.AssignedTo, t => t.MapFrom(t => t.UserNavigator))
               .ForMember(trp => trp.Status, t => t.MapFrom(t => t.TaskStatusNavigator));
              


            CreateMap<InteractionRequest, Interactions>()
                .ForMember(i => i.Date, ir => ir.MapFrom(ir => ir.Date))
                .ForMember(i => i.Notes, ir => ir.MapFrom(ir => ir.Notes))
                .ForMember(i => i.InteractionType, ir => ir.MapFrom(ir => ir.InteractionType));

            CreateMap<Interactions, InteractionResponse>()
                .ForMember(irp => irp.Id, i => i.MapFrom(i => i.InteractionID))
                .ForMember(irp => irp.Project, i => i.MapFrom(i => i.ProjectID))
                .ForMember(irp => irp.Date, i => i.MapFrom(i => i.Date))
                .ForMember(irp => irp.Notes, i => i.MapFrom(i => i.Notes))
                .ForMember(irp => irp.InteractionType, i => i.MapFrom(i => i.InteractionTypesNavigator));

            CreateMap<CampaignTypes, GenericResponse>()
                .ForMember(ctr => ctr.Id, ct => ct.MapFrom(ct => ct.Id))
                .ForMember(ctr => ctr.Name, ct => ct.MapFrom(ct => ct.Name));

            CreateMap<Users, UserReponse>()
                .ForMember(ur => ur.Id, u => u.MapFrom(u => u.UserID))
                .ForMember(ur => ur.Name, u => u.MapFrom(u => u.Name))
                .ForMember(ur => ur.Email, u => u.MapFrom(u => u.Email));

            CreateMap<Domain.Entities.TaskStatus, GenericResponse>()
                .ForMember(tsr => tsr.Id, ts => ts.MapFrom(ts => ts.Id))
                .ForMember(tsr => tsr.Name, ts => ts.MapFrom(ts => ts.Name));

            CreateMap<InteractionTypes, GenericResponse>()
                .ForMember(itr => itr.Id, it => it.MapFrom(it => it.Id))
                .ForMember(itr => itr.Name, it => it.MapFrom(it => it.Name));

        }
    }
}
