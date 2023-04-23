import { ProblemItem, Project, Session, SolutionItem } from '@/types/about'
import { AiOutlineOneToOne } from 'react-icons/ai'
import { BiCode } from 'react-icons/bi'
import { BsQuestionLg } from 'react-icons/bs'
import { FaRegLightbulb } from 'react-icons/fa'
import { GiAfrica } from 'react-icons/gi'
import { IoTriangleOutline } from 'react-icons/io5'
import { MdOutlineRocketLaunch } from 'react-icons/md'
import { TbGitPullRequestClosed } from 'react-icons/tb'

export const projects: Project[] = [
  {
    image: 'hakim-hub.png',
    project: 'Hakim Hub',
    description:
      'HakimHub is a platform that provides information about healthcare facilities and healthcare professionals in Ethiopia. Hakimhub makes information about hospitals, medical laboratories, and doctors conveniently accessible to its users.',
  },
  {
    image: 'track-sym.png',
    project: 'TrackSym',
    description:
      'TrackSym is a non-commercial app that uses crowd-sourcing to collect and visualize the density of the relevant Covid-19 symptoms. Symptom data, aggregated by places, can help people avoid visiting areas that are heavily populated by symptomatic people.',
  },
]
export const sessions: Session[] = [
  {
    session: 'Bi-Weekly Contests',
    description:
      'Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.',
    icon: <MdOutlineRocketLaunch />,
  },
  {
    session: 'Technical Training',
    description:
      '6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.',
    icon: <IoTriangleOutline />,
  },
  {
    session: 'Q&As',
    description:
      'In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.',
    icon: <BsQuestionLg />,
  },
  {
    session: 'Problem Solving Sessions',
    description:
      'We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.',
    icon: <BiCode />,
  },
  {
    session: 'Learning How To Approach',
    description:
      'Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.',
    icon: <TbGitPullRequestClosed />,
  },
  {
    session: 'Bi-weekly 1:1s',
    description:
      'In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.',
    icon: <AiOutlineOneToOne />,
  },
]

export const problemItemList: ProblemItem[] = [
  {
    icon: <GiAfrica />,
    description:
      'Africa’s future depends on innovation. Transformative technologies can drive rapid economic growth and lift millions of people out of poverty. However, university computer science education is misaligned with global market needs and fails to incorporate practice-based learning, leaving students unable to apply their skills in real-world contexts.',
  },
  {
    icon: <BiCode />,
    description:
      'With few global tech companies on the continent, aspiring engineers don’t have access to experienced mentors, or the opportunity to work on products that operate at scale. Smart and ambitious students who could create life-changing technologies aren’t able to reach their potential.',
  },
]

export const solutionItemList: SolutionItem[] = [
  {
    icon: <FaRegLightbulb />,
    description:
      'Offering students an ecosystem to actualize their ideas means that up-and-coming developers use their skills to benefit Africa, rather than taking their talent elsewhere.',
  },
]
