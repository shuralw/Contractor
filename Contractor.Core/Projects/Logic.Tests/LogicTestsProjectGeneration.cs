﻿using Contractor.Core.Helpers;
using Contractor.Core.Options;
using Contractor.Core.Tools;
using System.IO;

namespace Contractor.Core.Projects
{
    internal class LogicTestsProjectGeneration : IProjectGeneration
    {
        private static readonly string DomainFolder = ".Logic.Tests\\Model\\{Domain}\\{Entities}";

        private static readonly string TemplateFolder = Folder.Executable + @"\Projects\Logic.Tests\Templates";
        private static readonly string EntitiesCrudLogicTestsTemplateTemplateFileName = Path.Combine(TemplateFolder, "EntitiesCrudLogicTestsTemplate.txt");
        private static readonly string EntityTestValuesTemplateFileName = Path.Combine(TemplateFolder, "EntityTestValuesTemplate.txt");

        private static readonly string DbEntityDetailTestTemplateFileName = Path.Combine(TemplateFolder, "DbEntityDetailTestTemplate.txt");
        private static readonly string DbEntityTestTemplateFileName = Path.Combine(TemplateFolder, "DbEntityTestTemplate.txt");
        private static readonly string EntityDetailTestTemplateFileName = Path.Combine(TemplateFolder, "EntityDetailTestTemplate.txt");
        private static readonly string EntityTestTemplateFileName = Path.Combine(TemplateFolder, "EntityTestTemplate.txt");
        private static readonly string EntityCreateTestTemplateFileName = Path.Combine(TemplateFolder, "EntityCreateTestTemplate.txt");
        private static readonly string EntityUpdateTestTemplateFileName = Path.Combine(TemplateFolder, "EntityUpdateTestTemplate.txt");

        private static readonly string EntitiesCrudLogicTestsFileName = "EntitiesCrudLogicTests.cs";
        private static readonly string EntityTestValuesFileName = "EntityTestValues.cs";

        private static readonly string DbEntityDetailTestFileName = "DbEntityDetailTest.cs";
        private static readonly string DbEntityTestFileName = "DbEntityTest.cs";
        private static readonly string EntityDetailTestFileName = "EntityDetailTest.cs";
        private static readonly string EntityTestFileName = "EntityTest.cs";
        private static readonly string EntityCreateTestFileName = "EntityCreateTest.cs";
        private static readonly string EntityUpdateTestFileName = "EntityUpdateTest.cs";

        private readonly LogicDbDtoDetailTestFromAssertAddition logicDbDtoDetailTestFromAssertAddition;
        private readonly LogicDbDtoDetailTestToAssertAddition logicDbDtoDetailTestToAssertAddition;
        private readonly LogicDbDtoDetailTestMethodsAddition logicDbDtoDetailTestMethodsAddition;
        private readonly LogicDbDtoTestMethodsAddition logicDbDtoTestMethodsAddition;
        private readonly LogicDtoDetailTestFromAssertAddition logicDtoDetailTestFromAssertAddition;
        private readonly LogicDtoDetailTestMethodsAddition logicDtoDetailTestMethodsAddition;
        private readonly LogicDtoDetailTestToAssertAddition logicDtoDetailTestToAssertAddition;
        private readonly LogicDtoTestMethodsAddition logicDtoTestMethodsAddition;
        private readonly LogicDtoCreateTestMethodsAddition logicDtoCreateTestMethodsAddition;
        private readonly LogicDtoUpdateTestMethodsAddition logicDtoUpdateTestMethodsAddition;
        private readonly LogicDtoTestValuesAddition logicDtoTestValuesAddition;
        private readonly LogicDtoTestValuesRelationAddition logicDtoTestValuesRelationAddition;
        private readonly LogicTestsRelationAddition logicTestsRelationAddition;
        private readonly EntityCoreAddition entityCoreAddition;
        private readonly DtoAddition dtoAddition;
        private readonly DtoPropertyAddition propertyAddition;
        private readonly PathService pathService;

        public LogicTestsProjectGeneration(
            LogicDbDtoDetailTestFromAssertAddition logicDbDtoDetailTestFromAssertAddition,
            LogicDbDtoDetailTestToAssertAddition logicDbDtoDetailTestToAssertAddition,
            LogicDbDtoDetailTestMethodsAddition logicDbDtoDetailTestMethodsAddition,
            LogicDbDtoTestMethodsAddition logicDbDtoTestMethodsAddition,
            LogicDtoDetailTestFromAssertAddition logicDtoDetailTestFromAssertAddition,
            LogicDtoDetailTestMethodsAddition logicDtoDetailTestMethodsAddition,
            LogicDtoDetailTestToAssertAddition logicDtoDetailTestToAssertAddition,
            LogicDtoTestMethodsAddition logicDtoTestMethodsAddition,
            LogicDtoCreateTestMethodsAddition logicDtoCreateTestMethodsAddition,
            LogicDtoUpdateTestMethodsAddition logicDtoUpdateTestMethodsAddition,
            LogicDtoTestValuesAddition logicDtoTestValuesAddition,
            LogicDtoTestValuesRelationAddition logicDtoTestValuesRelationAddition,
            LogicTestsRelationAddition logicTestsRelationAddition,
            EntityCoreAddition entityCoreAddition,
            DtoAddition dtoAddition,
            DtoPropertyAddition propertyAddition,
            PathService pathService)
        {
            this.logicDbDtoDetailTestFromAssertAddition = logicDbDtoDetailTestFromAssertAddition;
            this.logicDbDtoDetailTestToAssertAddition = logicDbDtoDetailTestToAssertAddition;
            this.logicDtoDetailTestFromAssertAddition = logicDtoDetailTestFromAssertAddition;
            this.logicDtoDetailTestToAssertAddition = logicDtoDetailTestToAssertAddition;
            this.logicDbDtoDetailTestMethodsAddition = logicDbDtoDetailTestMethodsAddition;
            this.logicDbDtoTestMethodsAddition = logicDbDtoTestMethodsAddition;
            this.logicDtoDetailTestMethodsAddition = logicDtoDetailTestMethodsAddition;
            this.logicDtoTestMethodsAddition = logicDtoTestMethodsAddition;
            this.logicDtoCreateTestMethodsAddition = logicDtoCreateTestMethodsAddition;
            this.logicDtoUpdateTestMethodsAddition = logicDtoUpdateTestMethodsAddition;
            this.logicDtoTestValuesAddition = logicDtoTestValuesAddition;
            this.logicDtoTestValuesRelationAddition = logicDtoTestValuesRelationAddition;
            this.logicTestsRelationAddition = logicTestsRelationAddition;
            this.entityCoreAddition = entityCoreAddition;
            this.dtoAddition = dtoAddition;
            this.propertyAddition = propertyAddition;
            this.pathService = pathService;
        }

        public void AddDomain(IDomainAdditionOptions options)
        {
        }

        public void AddEntity(IEntityAdditionOptions options)
        {
            // Crud Tests
            this.pathService.AddEntityFolder(options, DomainFolder);

            this.entityCoreAddition.AddEntityCore(options, DomainFolder, EntitiesCrudLogicTestsTemplateTemplateFileName, EntitiesCrudLogicTestsFileName);

            // Entity Test Values
            this.entityCoreAddition.AddEntityCore(options, DomainFolder, EntityTestValuesTemplateFileName, EntityTestValuesFileName);

            // DTOs
            this.pathService.AddDtoFolder(options, DomainFolder);

            this.dtoAddition.AddDto(options, DomainFolder, DbEntityDetailTestTemplateFileName, DbEntityDetailTestFileName);
            this.dtoAddition.AddDto(options, DomainFolder, DbEntityTestTemplateFileName, DbEntityTestFileName);
            this.dtoAddition.AddDto(options, DomainFolder, EntityDetailTestTemplateFileName, EntityDetailTestFileName);
            this.dtoAddition.AddDto(options, DomainFolder, EntityTestTemplateFileName, EntityTestFileName);
            this.dtoAddition.AddDto(options, DomainFolder, EntityCreateTestTemplateFileName, EntityCreateTestFileName);
            this.dtoAddition.AddDto(options, DomainFolder, EntityUpdateTestTemplateFileName, EntityUpdateTestFileName);
        }

        public void AddProperty(IPropertyAdditionOptions options)
        {
            this.logicDtoTestValuesAddition.Add(options, DomainFolder, EntityTestValuesFileName);

            this.propertyAddition.AddPropertyToDTO(options, DomainFolder, DbEntityDetailTestFileName);
            this.logicDbDtoDetailTestMethodsAddition.Add(options, DomainFolder, DbEntityDetailTestFileName);

            this.propertyAddition.AddPropertyToDTO(options, DomainFolder, EntityDetailTestFileName);
            this.logicDtoDetailTestMethodsAddition.Add(options, DomainFolder, EntityDetailTestFileName);

            this.propertyAddition.AddPropertyToDTO(options, DomainFolder, DbEntityTestFileName);
            this.logicDbDtoTestMethodsAddition.Add(options, DomainFolder, DbEntityTestFileName);

            this.propertyAddition.AddPropertyToDTO(options, DomainFolder, EntityTestFileName);
            this.logicDtoTestMethodsAddition.Add(options, DomainFolder, EntityTestFileName);

            this.propertyAddition.AddPropertyToDTO(options, DomainFolder, EntityCreateTestFileName);
            this.logicDtoCreateTestMethodsAddition.Add(options, DomainFolder, EntityCreateTestFileName);

            this.propertyAddition.AddPropertyToDTO(options, DomainFolder, EntityUpdateTestFileName);
            this.logicDtoUpdateTestMethodsAddition.Add(options, DomainFolder, EntityUpdateTestFileName);
        }

        public void Add1ToNRelation(IRelationAdditionOptions options)
        {
            // From
            IPropertyAdditionOptions dbFromOptions = RelationAdditionOptions.GetPropertyForFrom(options, $"IEnumerable<IDb{options.EntityNameTo}>", $"{options.EntityNamePluralTo}");
            this.propertyAddition.AddPropertyToDTO(dbFromOptions, DomainFolder, DbEntityDetailTestFileName);
            this.logicDbDtoDetailTestFromAssertAddition.Add(options, DomainFolder, DbEntityDetailTestFileName);

            IPropertyAdditionOptions dtoFromOptions = RelationAdditionOptions.GetPropertyForFrom(options, $"IEnumerable<I{options.EntityNameTo}>", $"{options.EntityNamePluralTo}");
            this.propertyAddition.AddPropertyToDTO(dtoFromOptions, DomainFolder, EntityDetailTestFileName);
            this.logicDtoDetailTestFromAssertAddition.Add(options, DomainFolder, EntityDetailTestFileName);

            // To
            this.logicTestsRelationAddition.Add(options, DomainFolder, EntitiesCrudLogicTestsFileName);

            this.logicDtoTestValuesRelationAddition.Add(options, DomainFolder, EntityTestValuesFileName);

            IPropertyAdditionOptions dbToOptions = RelationAdditionOptions.GetPropertyForTo(options, $"IDb{options.EntityNameFrom}", $"{options.EntityNameFrom}");
            this.propertyAddition.AddPropertyToDTO(dbToOptions, DomainFolder, DbEntityDetailTestFileName);
            this.logicDbDtoDetailTestToAssertAddition.Add(options, DomainFolder, DbEntityDetailTestFileName);

            IPropertyAdditionOptions dtoToOptions = RelationAdditionOptions.GetPropertyForTo(options, $"I{options.EntityNameFrom}", $"{options.EntityNameFrom}");
            this.propertyAddition.AddPropertyToDTO(dtoToOptions, DomainFolder, EntityDetailTestFileName);
            this.logicDtoDetailTestToAssertAddition.Add(options, DomainFolder, EntityDetailTestFileName);

            IPropertyAdditionOptions guidPropertyOptions = RelationAdditionOptions.GetPropertyForTo(options, "Guid", $"{options.EntityNameFrom}Id");
            this.propertyAddition.AddPropertyToDTO(guidPropertyOptions, DomainFolder, DbEntityTestFileName);
            this.logicDbDtoTestMethodsAddition.Add(guidPropertyOptions, DomainFolder, DbEntityTestFileName);

            this.propertyAddition.AddPropertyToDTO(guidPropertyOptions, DomainFolder, EntityTestFileName);
            this.logicDtoTestMethodsAddition.Add(guidPropertyOptions, DomainFolder, EntityTestFileName);

            this.propertyAddition.AddPropertyToDTO(guidPropertyOptions, DomainFolder, EntityCreateTestFileName);
            this.logicDtoCreateTestMethodsAddition.Add(guidPropertyOptions, DomainFolder, EntityCreateTestFileName);

            this.propertyAddition.AddPropertyToDTO(guidPropertyOptions, DomainFolder, EntityUpdateTestFileName);
            this.logicDtoUpdateTestMethodsAddition.Add(guidPropertyOptions, DomainFolder, EntityUpdateTestFileName);
        }
    }
}