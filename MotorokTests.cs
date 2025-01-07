using FluentAssertions;
using SajatOldal.Models.Motorok;
namespace Motorok_Unit_test
{
    [TestClass]
    public sealed class MotorokTests
    {
        [TestMethod]
        public void Wheel_radius_Test()
        {
            var motorok = new Motorok();
            motorok.Tire = "225/50 R 16";
            motorok.Creep_factor = 0.94;
            motorok.Calculate_Wheel_radius();
            motorok.Wheel_radius.Should().Be(296.758);
        }
        [TestMethod]
        public void M_P_Max_Test()
        {
            var motorok = new Motorok();
            motorok.Pn_max = 235;
            motorok.n_pn_max = 6000;
            motorok.Calculate_M_P_Max();
            motorok.M_P_Max.Should().BeApproximately(374.014, 0.001);
        }
        [TestMethod]
        public void Calculate_ford_to_Radsec_Test()
        {
            var motorok = new Motorok();
            double result = motorok.Calculate_ford_to_Radsec(6000);
            result.Should().BeApproximately(628.319, 0.001);
        }
        [TestMethod]
        public void P_M_Max_Test()
        {
            var motorok = new Motorok();
            motorok.M_max = 430;
            motorok.n_M_max = 6000;
            motorok.Calculate_P_M_Max();
            motorok.P_M_Max.Should().BeApproximately(270.176, 0.001);
        }
        [TestMethod]
        public void Calculate_Speed_of_the_wheel_Test()
        {
            var motorok = new Motorok();
            motorok.Transmissions.Add(3.87);
            motorok.Gear_ratio = 2.538;
            motorok.n_M_max = 3000;
            motorok.Wheel_radius = 296.758;
            var result = motorok.Calculate_Speed_of_the_wheel(motorok.n_M_max, motorok.Transmissions[0]);
            result = motorok.MeterminuteToKmhour(result);
            result.Should().BeApproximately(34.171, 0.001);
        }
        [TestMethod]
        public void Calculate_Speed_of_the_wheels_Test()
        {
            var motorok = new Motorok();
            motorok.Transmissions.Add(3.87);
            motorok.Transmissions.Add(2.25);
            motorok.Transmissions.Add(1.44);
            motorok.Transmissions.Add(1.0);
            motorok.Gear_ratio = 2.538;
            motorok.n_pn_max = 3000;
            motorok.Wheel_radius = 296.758;
            motorok.Calculate_Speed_of_the_wheels_P();
            var result = motorok.MeterminuteToKmhour(motorok.Speed_of_the_Wheels_P[0]);
            result.Should().BeApproximately(34.171, 0.001);
            motorok.MeterminuteToKmhour(motorok.Speed_of_the_Wheels_P[1]).Should().BeApproximately(58.773, 0.001);
            motorok.MeterminuteToKmhour(motorok.Speed_of_the_Wheels_P[2]).Should().BeApproximately(91.833, 0.001);
            motorok.MeterminuteToKmhour(motorok.Speed_of_the_Wheels_P[3]).Should().BeApproximately(132.24, 0.001);
        }
        [TestMethod]
        public void Calculate_Force_of_the_wheel_Test()
        {
            var motorok = new Motorok();
            motorok.Transmissions.Add(3.89);
            motorok.Gear_ratio = 3.92;
            motorok.M_max = 182;
            motorok.Transmission_efficiency =0.92;
            motorok.Wheel_radius = 307.38;
            var result = motorok.Calculate_Force_of_the_wheel(motorok.M_max, motorok.Transmissions[0]);
            result.Should().BeApproximately(8306.523, 0.001);
        }
        [TestMethod]
        public void Calculate_Force_of_the_wheels_P_Test()
        {
            var motorok = new Motorok();
            motorok.Transmissions.Add(3.89);
            motorok.Transmissions.Add(2.084);
            motorok.Transmissions.Add(1.342);
            motorok.Transmissions.Add(1.0);
            motorok.Transmissions.Add(0.822);
            motorok.Gear_ratio = 3.92;
            motorok.Transmission_efficiency = 0.92;
            motorok.Wheel_radius = 307.38;
            motorok.M_P_Max = 151.472;
            motorok.Calculate_Force_of_the_wheels_P();
            var result = motorok.Force_of_the_Wheels_P[0];
            result.Should().BeApproximately(6913.217, 0.001);
            motorok.Force_of_the_Wheels_P[1].Should().BeApproximately(3703.636, 0.001);
            motorok.Force_of_the_Wheels_P[2].Should().BeApproximately(2384.971, 0.001);
            motorok.Force_of_the_Wheels_P[3].Should().BeApproximately(1777.176, 0.001);
            motorok.Force_of_the_Wheels_P[4].Should().BeApproximately(1460.839, 0.001);
        }
        public void Calculate_Force_of_the_wheels_M_Test()
        {
            var motorok = new Motorok();
            motorok.Transmissions.Add(3.89);
            motorok.Transmissions.Add(2.084);
            motorok.Transmissions.Add(1.342);
            motorok.Transmissions.Add(1.0);
            motorok.Transmissions.Add(0.822);
            motorok.Gear_ratio = 3.92;
            motorok.Transmission_efficiency = 0.92;
            motorok.Wheel_radius = 307.38;
            motorok.M_max = 182;
            motorok.Calculate_Force_of_the_wheels_M();
            var result = motorok.Force_of_the_Wheels_P[0];
            result.Should().BeApproximately(8306.523, 0.001);
            motorok.Force_of_the_Wheels_M[1].Should().BeApproximately(4450.076, 0.001);
            motorok.Force_of_the_Wheels_M[2].Should().BeApproximately(2865.644, 0.001);
            motorok.Force_of_the_Wheels_M[3].Should().BeApproximately(2135.353, 0.001);
            motorok.Force_of_the_Wheels_M[4].Should().BeApproximately(1755.26, 0.001);
        }
        [TestMethod]
        public void Calculate_Rolling_resistance_Test()
        {
            var motorok = new Motorok();
            motorok.Max_Weight = 1850;
            motorok.Rolling_Resistance_Factor = 0.015;
            motorok.Calculate_Rolling_resistance();
            motorok.Rolling_resistance.Should().BeApproximately(272.227,0.001);
        }
        [TestMethod]
        public void Calculate_the_hill_Test()
        {
            var motorok = new Motorok();
            motorok.Slope_of_rise = 13.0;
            motorok.Calculate_the_hill();
            motorok.The_hill_on_degree.Should().BeApproximately(7.407, 0.001);
        }
        [TestMethod]
        public void Calculate_Rolling_resistance_on_the_hill_Test()
        {
            var motorok = new Motorok();
            motorok.Max_Weight = 1850;
            motorok.Rolling_Resistance_Factor = 0.015;
            motorok.Slope_of_rise = 13.0;
            motorok.Calculate_Rolling_resistance_on_a_hill();
            motorok.Rolling_resistance_on_a_hill.Should().BeApproximately(269.956, 0.001);
        }
        [TestMethod]
        public void Calculate_Ascent_resistance_Test()
        {
            var motorok = new Motorok();
            motorok.Max_Weight = 1850;
            motorok.Rolling_Resistance_Factor = 0.015;
            motorok.Slope_of_rise = 13.0;
            motorok.Calculate_Ascent_resistance();
            motorok.Ascent_resistance.Should().BeApproximately(2339.619, 0.001);
        }
        [TestMethod]
        public void Calculate_Cross_Section_Test()
        {
            var motorok = new Motorok();
            motorok.Hight = 1440;
            motorok.Width = 1760;
            motorok.Calculate_Cross_Section();
            motorok.Cross_Section.Should().BeApproximately(1.977, 0.001);
        }
        [TestMethod]
        public void Calculate_AirResistance_Test()
        {
            var motorok = new Motorok();
            motorok.Cross_Section = 1.977;
            motorok.AirDensity = 1.23;
            motorok.Drag_coefficient = 0.32;            
            var result = motorok.Calculate_AirResistance(12.243*60000);
            result.Should().BeApproximately(58.318, 0.001);
        }
        [TestMethod]
        public void Calculate_AirResistanceses_Test()
        {
            var motorok = new Motorok();
            motorok.Cross_Section = 1.977;
            motorok.AirDensity = 1.23;
            motorok.Drag_coefficient = 0.32;
            motorok.Speed_of_the_Wheels_P.Add(7.388 * 60000);
            motorok.Speed_of_the_Wheels_P.Add(13.791 * 60000);
            motorok.Speed_of_the_Wheels_P.Add(21.416 * 60000);
            motorok.Speed_of_the_Wheels_P.Add(28.74 * 60000);
            motorok.Speed_of_the_Wheels_P.Add(34.963 * 60000);

            motorok.Calculate_AirResistanceses_P();

            motorok.AirResistances_P[0].Should().BeApproximately(21.236, 0.001);
            motorok.AirResistances_P[1].Should().BeApproximately(73.998, 0.001);
            motorok.AirResistances_P[2].Should().BeApproximately(178.446, 0.001);
            motorok.AirResistances_P[3].Should().BeApproximately(321.369, 0.001);
            motorok.AirResistances_P[4].Should().BeApproximately(475.607, 0.001);
        }
        [TestMethod]
        public void Force_Required_For_Accelaration_P_Test()
        {
            var motorok = new Motorok();
            motorok.Force_of_the_Wheels_P.Add(5507.31);
            motorok.Rolling_resistance = 129.691;
            motorok.AirResistances_P.Add(23.398);
            motorok.Ascent_resistance = 1426.598;

            motorok.ForcesRequiredForAccelaration_P.Add(motorok.Force_Required_For_Accelaration_P(0));

            motorok.ForcesRequiredForAccelaration_P[0].Should().BeApproximately(3927.624, 0.001);
        }
        [TestMethod]
        public void Force_Required_For_Accelaration_M_Test()
        {
            var motorok = new Motorok();
            motorok.Force_of_the_Wheels_M.Add(6913.2);
            motorok.Rolling_resistance = 269.956;
            motorok.AirResistances_M.Add(58.316);
            motorok.Ascent_resistance =  2339.618;

            motorok.ForcesRequiredForAccelaration_M.Add(motorok.Force_Required_For_Accelaration_M(0));

            motorok.ForcesRequiredForAccelaration_M[0].Should().BeApproximately(4245.31, 0.001);
        }
        [TestMethod]
        public void Calculate_Forces_Required_For_Accelaration_P_Test()
        {
            var motorok = new Motorok();
            motorok.AirResistances_P.Add(58.316);
            motorok.AirResistances_P.Add(203.185);
            motorok.AirResistances_P.Add(489.984);
            motorok.AirResistances_P.Add(882.444);
            motorok.AirResistances_P.Add(1306.001);

            motorok.Force_of_the_Wheels_P.Add(6913.2);
            motorok.Force_of_the_Wheels_P.Add(3703.627);
            motorok.Force_of_the_Wheels_P.Add(2386.965);
            motorok.Force_of_the_Wheels_P.Add(1777.172);
            motorok.Force_of_the_Wheels_P.Add(1460.836);

            motorok.Rolling_resistance = 269.956;
            motorok.Ascent_resistance = 2339.618;

            motorok.Calculate_Forces_Required_For_Accelaration_P();
            motorok.ForcesRequiredForAccelaration_P[0].Should().BeApproximately(4245.31, 0.001);
            motorok.ForcesRequiredForAccelaration_P[1].Should().BeApproximately(890.868, 0.001);
            motorok.ForcesRequiredForAccelaration_P[2].Should().BeApproximately(-712.593, 0.001);
            motorok.ForcesRequiredForAccelaration_P[3].Should().BeApproximately(-1714.846, 0.001);
            motorok.ForcesRequiredForAccelaration_P[4].Should().BeApproximately(-2454.739, 0.001);
        }
        [TestMethod]
        public void Calculate_Forces_Required_For_Accelaration_M_Test()
        {
            var motorok = new Motorok();

            motorok.AirResistances_M.Add(58.316);
            motorok.AirResistances_M.Add(203.185);
            motorok.AirResistances_M.Add(489.984);
            motorok.AirResistances_M.Add(882.444);
            motorok.AirResistances_M.Add(1306.001);

            motorok.Force_of_the_Wheels_M.Add(6913.2);
            motorok.Force_of_the_Wheels_M.Add(3703.627);
            motorok.Force_of_the_Wheels_M.Add(2386.965);
            motorok.Force_of_the_Wheels_M.Add(1777.172);
            motorok.Force_of_the_Wheels_M.Add(1460.836);

            motorok.Rolling_resistance = 269.956;
            motorok.Ascent_resistance = 2339.618;

            motorok.Calculate_Forces_Required_For_Accelaration_M();
            motorok.ForcesRequiredForAccelaration_M[0].Should().BeApproximately(4245.31, 0.001);
            motorok.ForcesRequiredForAccelaration_M[1].Should().BeApproximately(890.868, 0.001);
            motorok.ForcesRequiredForAccelaration_M[2].Should().BeApproximately(-712.593, 0.001);
            motorok.ForcesRequiredForAccelaration_M[3].Should().BeApproximately(-1714.846, 0.001);
            motorok.ForcesRequiredForAccelaration_M[4].Should().BeApproximately(-2454.739, 0.001);
        }
        [TestMethod]
        public void Acceleration_On_The_Hill_Test()
        {
            var motorok = new Motorok();
            motorok.Reduction_constant_of_rotating_masses = 1.2;
            motorok.Max_Weight = 1850;

            var result = motorok.Acceleration_On_The_Hill(5675.713);

            result.Should().BeApproximately(2.557, 0.001);
        }
        [TestMethod]
        public void Calculate_Acceleration_On_The_Hill_M_Test()
        {
            var motorok = new Motorok();
            motorok.Reduction_constant_of_rotating_masses = 1.2;
            motorok.Max_Weight = 1850;

            motorok.ForcesRequiredForAccelaration_M.Add(5675.713);
            motorok.ForcesRequiredForAccelaration_M.Add(1766.512);
            motorok.ForcesRequiredForAccelaration_M.Add(77.64);
            motorok.ForcesRequiredForAccelaration_M.Add(-795.563);
            motorok.ForcesRequiredForAccelaration_M.Add(-1329.894);

            motorok.Calculate_Acceleration_On_The_Hill_M();
            motorok.Accelarations_On_The_Hill_M[0].Should().BeApproximately(2.557, 0.001);
            motorok.Accelarations_On_The_Hill_M[1].Should().BeApproximately(0.796, 0.001);
            motorok.Accelarations_On_The_Hill_M[2].Should().BeApproximately(0.035, 0.001);
            motorok.Accelarations_On_The_Hill_M[3].Should().BeApproximately(-0.358, 0.001);
            motorok.Accelarations_On_The_Hill_M[4].Should().BeApproximately(-0.599, 0.001);
        }
        [TestMethod]
        public void Calculate_Acceleration_On_The_Hill_P_Test()
        {
            var motorok = new Motorok();
            motorok.Reduction_constant_of_rotating_masses = 1.2;
            motorok.Max_Weight = 1850;

            motorok.ForcesRequiredForAccelaration_P.Add(5675.713);
            motorok.ForcesRequiredForAccelaration_P.Add(1766.512);
            motorok.ForcesRequiredForAccelaration_P.Add(77.64);
            motorok.ForcesRequiredForAccelaration_P.Add(-795.563);
            motorok.ForcesRequiredForAccelaration_P.Add(-1329.894);

            motorok.Calculate_Acceleration_On_The_Hill_P();
            motorok.Accelarations_On_The_Hill_P[0].Should().BeApproximately(2.557, 0.001);
            motorok.Accelarations_On_The_Hill_P[1].Should().BeApproximately(0.796, 0.001);
            motorok.Accelarations_On_The_Hill_P[2].Should().BeApproximately(0.035, 0.001);
            motorok.Accelarations_On_The_Hill_P[3].Should().BeApproximately(-0.358, 0.001);
            motorok.Accelarations_On_The_Hill_P[4].Should().BeApproximately(-0.599, 0.001);
        }
        [TestMethod]
        public void Dynamic_Factor_Test()
        {
            var motorok = new Motorok();
            motorok.Reduction_constant_of_rotating_masses = 1.2;
            motorok.Max_Weight = 1850;

            var result = motorok.Dynamic_Factor(6913.2,58.316);

            result.Should().BeApproximately(0.378, 0.001);
        }
        [TestMethod]
        public void Calculate_Dynamic_Factors_Test()
        {
            var motorok = new Motorok();
            motorok.Max_Weight = 1850;

            motorok.AirResistances_P.Add(58.316);
            motorok.AirResistances_P.Add(203.185);
            motorok.AirResistances_P.Add(489.984);
            motorok.AirResistances_P.Add(882.444);
            motorok.AirResistances_P.Add(1306.001);

            motorok.Force_of_the_Wheels_P.Add(6913.2);
            motorok.Force_of_the_Wheels_P.Add(3703.627);
            motorok.Force_of_the_Wheels_P.Add(2386.965);
            motorok.Force_of_the_Wheels_P.Add(1777.172);
            motorok.Force_of_the_Wheels_P.Add(1460.836);

            motorok.Calculate_Dynamic_Factors();

            motorok.Dynamic_Factors[0].Should().BeApproximately(0.378, 0.001);
            motorok.Dynamic_Factors[1].Should().BeApproximately(0.193, 0.001);
            motorok.Dynamic_Factors[2].Should().BeApproximately(0.104, 0.001);
            motorok.Dynamic_Factors[3].Should().BeApproximately(0.049, 0.001);
            motorok.Dynamic_Factors[4].Should().BeApproximately(0.009, 0.001);
        }

        [TestMethod]
        public void ConvertThelistToKmperh_Test()
        {
            var motorok = new Motorok();

            motorok.Speed_of_the_Wheels_M.Add(443289.9145521624);
            motorok.Speed_of_the_Wheels_M.Add(827446.14568517846);
            motorok.Speed_of_the_Wheels_M.Add(1284946.1755647629);
            motorok.Speed_of_the_Wheels_M.Add(1724397.767607912);
            motorok.Speed_of_the_Wheels_M.Add(2097807.5031726426);

            motorok.Speed_In_Kmperh_M = motorok.ConvertThelistToKmperh(motorok.Speed_of_the_Wheels_M);

            motorok.Speed_In_Kmperh_M[0].Should().BeApproximately(26.597, 0.001);
            motorok.Speed_of_the_Wheels_M[0].Should().BeApproximately(443289.9145521624, 0.001);
        }
        [TestMethod]
        public void SummTheForces_Test()
        {
            var motorok = new Motorok();

            motorok.AirResistances_M.Add(10);
            motorok.Ascent_resistance = 10;
            motorok.Rolling_resistance = 10;
            motorok.ForceAgistTheCar_M = motorok.SummTheForces(motorok.AirResistances_M);

            motorok.ForceAgistTheCar_M[0].Should().BeApproximately(30, 0.001);
        }



    }
}
