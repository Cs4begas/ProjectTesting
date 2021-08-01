using MANIPULATEDATA.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MANIPULATEDATA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GROUP_GRADE> groupGrades =FindGroupGrade(MockGroup(), MockMembers());
        }
        static List<GROUP_GRADE> FindGroupGrade(List<GROUP> groups, List<MEMBER> members)
        {
            List<GROUP_GRADE> results = new List<GROUP_GRADE>();
            foreach (GROUP group in groups)
            {
                List<MEMBER> memberGroups = members.Where(x => x.groupId == group.id).OrderByDescending(x => x.score).ToList();
                int memberGroupCount = memberGroups.Count;
                decimal? avgscore = FindAverageScore(memberGroups, memberGroupCount);
                string groupGrade = FindGradeFromScore(avgscore);
                GROUP_GRADE result = new GROUP_GRADE()
                {
                    groupName = group.groupName,
                    groupMembers = memberGroupCount,
                    groupScore = avgscore,
                    groupGrade = groupGrade
                };
                results.Add(result);
            }
            return results;
        }

        private static string FindGradeFromScore(decimal? avgscore)
        {
            string groupGrade;
            if (avgscore >= 80)
            {
                groupGrade = "A";
            }
            else if (avgscore >= 70)
            {
                groupGrade = "B";
            }
            else if (avgscore >= 60)
            {
                groupGrade = "C";
            }
            else
            {
                groupGrade = null; // Definition is "F" But Result is null then i go with null
            }

            return groupGrade;
        }

        private static decimal? FindAverageScore(List<MEMBER> memberGroups, int memberGroupCount)
        {
            decimal avgscore;
            if (memberGroups.Count == 0)
            {
                return null;
            }
            if (memberGroupCount > 2)
            {
                avgscore = (memberGroups.Skip(1).SkipLast(1).Select(x => x.score).Sum() / (decimal)(memberGroups.Count - 2));
            }
            else
            {
                avgscore = (decimal)memberGroups.Select(x => x.score).Average();
            }

            return avgscore;
        }

        static List<GROUP> MockGroup()
        {
            List<GROUP> groups = new List<GROUP>()
            {
                new GROUP
                {
                    id = 1,
                    groupName = "G1"
                },
                new GROUP
                {
                    id = 2,
                    groupName = "G2"
                },
                new GROUP
                {
                    id = 3,
                    groupName = "G3"
                },
                new GROUP
                {
                    id = 4,
                    groupName = "G4"
                }

            };
            return groups;
        }
        static List<MEMBER> MockMembers()
        {
            List<MEMBER> members = new List<MEMBER>()
            {
                new MEMBER
                {
                    id = 1,
                    groupId = 1,
                    name = "G1-1",
                    score = 90
                },
                new MEMBER
                {
                    id = 2,
                    groupId = 1,
                    name = "G1-2",
                    score = 85
                },
                new MEMBER
                {
                    id = 3,
                    groupId = 1,
                    name = "G1-3",
                    score = 80
                },
                new MEMBER
                {
                    id = 4,
                    groupId = 1,
                    name = "G1-4",
                    score = 70
                },
                new MEMBER
                {
                    id = 5,
                    groupId = 2,
                    name = "G2-1",
                    score = 95
                },
                new MEMBER
                {
                    id = 6,
                    groupId = 2,
                    name = "G2-2",
                    score = 70
                },
                new MEMBER
                {
                    id = 7,
                    groupId = 2,
                    name = "G2-3",
                    score = 70
                },
                new MEMBER
                {
                    id = 8,
                    groupId = 2,
                    name = "G2-4",
                    score = 70
                },
                new MEMBER
                {
                    id = 9,
                    groupId = 2,
                    name = "G2-5",
                    score = 60
                },
                new MEMBER
                {
                    id = 10,
                    groupId = 3,
                    name = "G3-1",
                    score = 65
                }
            };
            return members;
        }
    }
}
