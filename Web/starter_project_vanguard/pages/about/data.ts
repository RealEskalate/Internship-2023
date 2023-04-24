import hakimHub from '../../public/aboutus/hakimhub.svg'
import howToApproach from '../../public/aboutus/how_to_approach.svg'
import problemSolvingSession from '../../public/aboutus/problem_solving_session.svg'
import qAndA from '../../public/aboutus/q&a.svg'
import technicalTraining from '../../public/aboutus/technical_training.svg'
import trackSys from '../../public/aboutus/tracksys.svg'
import weeklyContests from '../../public/aboutus/weekly_contests.svg'
import weeklyOneOnOnes from '../../public/aboutus/weekly_one_on_ones.svg'

export const socialProjects = [
  {
    image: hakimHub,
    title: 'Hakim Hub',
    content:
      'HakimHub is a platform that provides information about healthcare\
            facilities and healthcare professionals in Ethiopia. Hakimhub makes\
            information about hospitals, medical laboratories, and doctors\
            conveniently accessible to its users.',
    leftAligned: false,
    isImageLeft: true,
  },
  {
    image: trackSys,
    title: 'Track Sym',
    content:
      'TrackSym is a non-commercial app that uses crowd-sourcing to collect\
              and visualize the density of the relevant Covid-19 symptoms. Symptom\
              data, aggregated by places, can help people avoid visiting areas\
              that are heavily populated by symptomatic people.',
    leftAligned: true,
    isImageLeft: false,
  },
]

export const a2svSessions = [
  {
    image: weeklyContests,
    title: 'Bi-weekly contests',
    content:
      'Contests help us to get better at competitive programming and\
            problem-solving. We use online platforms like Leetcode and\
            Codeforces.',
  },
  {
    image: technicalTraining,
    title: 'Technical Training',
    content:
      '6 days a week, 3 hours of lectures and practice sessions to improve \
          technical problem-solving skills.',
  },
  {
    image: qAndA,
    title: 'Q&As',
    content:
      'In Q&As, we get to know engineers, founders, and entrepreneurs from \
          top tech companies. We see that they are normal people like us and \
          we learn the best practices.',
  },
  {
    image: problemSolvingSession,
    title: 'Problem Solving Sessions',
    content:
      'We solve technical problems on a whiteboard while explaining to the \
          class. It helps to get a feel of an interview environment.',
  },
  {
    image: howToApproach,
    title: 'Learn How to Approach Sessions',
    content:
      'Students observe how an experienced problem solver approaches a\
          problem from understanding it to implementing a working solution.',
  },
  {
    image: weeklyOneOnOnes,
    title: 'Bi-weekly 1-1s',
    content:
      'In 1:1s, we can talk about anything that matters; clearly no \
          boundaries. The more we speak our minds without a filter, the better \
          for the team.',
  },
]
