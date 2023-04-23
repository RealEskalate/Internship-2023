import { ProblemItem, Project, Session } from '@/types/AboutTypes'

export const Projects: Project[] = [
  {
    image: '/about/hakimhub.png',
    project: 'Hakim Hub',
    description:
      'HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.',
  },
  {
    image: '/about/tracksym.png',
    project: 'TrackSym',
    description:
      'TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms. Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.',
  },
]
export const Sessions: Session[] = [
  {
    session: 'Bi-Weekly Contests',
    description:
      'Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.',
    image: '/about/biweeklycontest.svg',
  },
  {
    session: 'Technical Training',
    description:
      '6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.',
    image: '/about//technicaltraining.svg',
  },
  {
    session: 'Q&As',
    description:
      'In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.',
    image: '/about//qanda.svg',
  },
  {
    session: 'Problem Solving Sessions',
    description:
      'We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.',
    image: '/about/problemsolving.svg',
  },
  {
    session: 'Learning How To Approach',
    description:
      'Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.',
    image: '/about/approach.svg',
  },
  {
    session: 'Bi-weekly 1:1s',
    description:
      'In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.',
    image: '/about/biweeklyones.svg',
  },
]

export const ProblemItemList: ProblemItem[] = [
  {
    icon: '/about/africa.svg',
    description:
      'Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.',
  },
  {
    icon: '/about/code.svg',
    description:
      'With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential.',
  },
]

export const SolutionItemList: ProblemItem[] = [
  {
    icon: '/about/idea.svg',
    description:
      'Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.',
  },
]
