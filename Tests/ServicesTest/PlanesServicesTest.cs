using System.Collections.Generic;
using Moq;
using Unir.Aggregates.Asignaturas;
using Unir.Aggregates.Estudios;
using Unir.Aggregates.Planes;
using Unir.Services.Impl;
using Xunit;

namespace Unir.ServicesTest
{
    public class PlanesServicesTest
    {
        [Fact]
        public void VerificacionPlanPasaTodasLasCondiciones()
        {
            // Arrange
            var plan = new Plan
            {
                Estudio = new Estudio { AprobadoAneca = true },
                Asignaturas = new List<AsignaturaPlan> 
                {
                    new AsignaturaPlan { Asignatura = new Asignatura { Optativa = false } },
                    new AsignaturaPlan { Asignatura = new Asignatura { Optativa = true } }
                }
            };

            // Act
            var service = ServicesResolver.Resolve<PlanesService>();
            var result = service.IsPlanValido(plan);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void VerificacionPlanFallaPorEstudioNoAprobado()
        {
            // Arrange
            var plan = new Plan
            {
                Estudio = new Estudio { AprobadoAneca = false }
            };

            // Act
            var service = ServicesResolver.Resolve<PlanesService>();
            var result = service.IsPlanValido(plan);

            // Assert
            Assert.False(result);
        }
    
        [Fact]
        public void AprobarPlanResultaEnCambioDeEstado()
        {
            // Arrange
            var plan = new Plan
            {
                Id = 1,
                Aprobado = false,
                Estudio = new Estudio { AprobadoAneca = true },
                Asignaturas = new List<AsignaturaPlan> 
                {
                    new AsignaturaPlan { Asignatura = new Asignatura { Optativa = false } },
                    new AsignaturaPlan { Asignatura = new Asignatura { Optativa = true } }
                }
            };

            var mockRepoPlanes = new Mock<IPlanesRepository>();
            mockRepoPlanes.Setup(r => r.Get(plan.Id)).Returns(plan);

            // Act
            var service = ServicesResolver.Resolve<PlanesService>(mockRepoPlanes.Object);
            var result = service.AprobarPlan(plan.Id);

            // Assert
            Assert.True(plan.Aprobado);
        }
    }
}