﻿using Contractor.Core.Options;
using Contractor.Core.Tools;
using System.IO;

namespace Contractor.Core.Projects.Frontend.Model
{
    internal class IEntityUpdateGeneration : ClassGeneration
    {
        private static readonly string TemplatePath =
            Path.Combine(ModelProjectGeneration.TemplateFolder, "i-entity-kebab-update.template.txt");

        private static readonly string FileName = "dtos\\i-entity-kebab-update.ts";

        private readonly FrontendDtoAddition frontendDtoAddition;
        private readonly FrontendDtoPropertyAddition frontendDtoPropertyAddition;
        private readonly FrontendDtoPropertyMethodAddition frontendDtoPropertyMethodAddition;
        private readonly IEntityUpdateMethodAddition entityUpdateMethodAddition;

        public IEntityUpdateGeneration(
            FrontendDtoAddition frontendDtoAddition,
            FrontendDtoPropertyAddition frontendDtoPropertyAddition,
            FrontendDtoPropertyMethodAddition frontendDtoPropertyMethodAddition,
            IEntityUpdateMethodAddition entityUpdateMethodAddition)
        {
            this.frontendDtoAddition = frontendDtoAddition;
            this.frontendDtoPropertyAddition = frontendDtoPropertyAddition;
            this.frontendDtoPropertyMethodAddition = frontendDtoPropertyMethodAddition;
            this.entityUpdateMethodAddition = entityUpdateMethodAddition;
        }

        protected override void AddDomain(IDomainAdditionOptions options)
        {
        }

        protected override void AddEntity(IEntityAdditionOptions options)
        {
            this.frontendDtoAddition.AddDto(options, ModelProjectGeneration.DomainFolder, TemplatePath, FileName);
        }

        protected override void AddProperty(IPropertyAdditionOptions options)
        {
            this.frontendDtoPropertyAddition.AddPropertyToDTO(options, ModelProjectGeneration.DomainFolder, FileName);

            this.frontendDtoPropertyMethodAddition.AddPropertyToDTO(options, "toApiEntityUpdate", "entityUpdate", ModelProjectGeneration.DomainFolder, FileName);

            this.frontendDtoPropertyMethodAddition.AddPropertyToDTO(options, "fromEntityDetail", "entityDetail", ModelProjectGeneration.DomainFolder, FileName);
        }

        protected override void Add1ToNRelation(IRelationAdditionOptions options)
        {
            IPropertyAdditionOptions toOptions =
                RelationAdditionOptions.GetPropertyForTo(options, "Guid", $"{options.EntityNameLowerFrom}Id");
            this.frontendDtoPropertyAddition.AddPropertyToDTO(toOptions, ModelProjectGeneration.DomainFolder, FileName);

            this.frontendDtoPropertyMethodAddition.AddPropertyToDTO(toOptions, "toApiEntityUpdate", "entityUpdate", ModelProjectGeneration.DomainFolder, FileName);

            this.entityUpdateMethodAddition.AddPropertyToDTO(options, ModelProjectGeneration.DomainFolder, FileName);
        }
    }
}