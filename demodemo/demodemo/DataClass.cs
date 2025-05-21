using demodemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace demodemo
{
    public class DataClass
    {
        public static ShortsdbContext context = new ShortsdbContext();

        public static List<Agent> GetAgents()
        {
            return context.Agents.Include(a => a.IdAgentTypeNavigation).Include(a => a.AgentsShorts).ToList();
        }

        public static List<Director> GetDirectors()
        {
            return context.Directors.ToList();
        }

        public static List<Address> GetAddresses()
        {
            return context.Addresses.ToList();
        }

        public static List<AgentType> GetAgentTypes()
        {
            return context.AgentTypes.ToList();
        }

        public static bool AddAgent(Agent agent)
        {
            try
            {
                context.Agents.Add(agent);
                context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public static void DeleteAgent(Agent agent)
        {
            try
            {
                context.Agents.Remove(agent);
                context.SaveChanges();
            } catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении агента");
            }
        }

        public static void EditAgent(Agent agent)
        {
            try
            {
                var edityAgent = context.Agents.FirstOrDefault(a => a.IdAgent == agent.IdAgent);
                if (edityAgent != null)
                {
                    context.Entry(edityAgent).CurrentValues.SetValues(agent);
                    context.SaveChanges();
                } else
                {
                    MessageBox.Show("Такого агента не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении агента");
            }
        }
    }
}
