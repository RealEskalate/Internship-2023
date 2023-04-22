import A2SVSession from '@/components/about/A2SVSession'
import CenteredImage from '@/components/about/CenteredImage'
import ImagePragraph from '@/components/about/ImagePragraph'
import SocialProject from '@/components/about/SocialProject'
import Image from 'next/image'
import africaIcon from '../../public/aboutus/africa_icon.svg'
import codingIcon from '../../public/aboutus/coding_icon.svg'
import developmentImage from '../../public/aboutus/development_phase.svg'
import educationImage from '../../public/aboutus/education_process.svg'
import growthRate from '../../public/aboutus/growth_rate.svg'
import hakimHub from '../../public/aboutus/hakimhub.svg'
import howToApproach from '../../public/aboutus/how_to_approach.svg'
import howWeAreSolving from '../../public/aboutus/how_we_are_solving.svg'
import lightIcon from '../../public/aboutus/light_icon.svg'
import problemImage from '../../public/aboutus/problem_image.svg'
import problemSolvingSession from '../../public/aboutus/problem_solving_session.svg'
import qAndA from '../../public/aboutus/q&a.svg'
import technicalTraining from '../../public/aboutus/technical_training.svg'
import trackSys from '../../public/aboutus/tracksys.svg'
import weeklyContests from '../../public/aboutus/weekly_contests.svg'
import weeklyOneOnOnes from '../../public/aboutus/weekly_one_on_ones.svg'

function AboutPage() {
  return (
    <div className="bg-white p-10">
      <div className="grid grid-cols-2 gap-10">
        <div>
          <p className="font-extrabold text-[#2B2A35] text-4xl">
            <span className="font-lato text-[#264FAD]">Africa </span> to Silicon
            Valley
          </p>
          <p className="py-7">
            A2SV is a social enterprise that enables high-potential university
            students to create digital solutions to Africa’s most pressing
            problems.
          </p>
          <button className="bg-[#264FAD] hover:bg-blue-700 text-white font-bold py-2 px-4 rounded m-auto">
            Meet Our Team
          </button>
          <p className="py-7">
            A2SV is a social enterprise that enables high-potential university
            students to create digital solutions to Africa’s most pressing
            problems.
          </p>
        </div>
        <div>
          <div className="grid grid-cols-2 gap-4 bg-white text-size">
            <p className="col-span-2 font-semibold">Group Activities</p>
            <div className="relative overflow-hidden rounded-lg shadow-lg cursor-pointer">
              <Image
                className="object-cover w-full h-48"
                src={educationImage}
                alt={''}
              ></Image>
              <div className="absolute top-0 left-0 px-6 py-4 text-center">
                <h4 className="mt-10 pt-6 text-xl font-semibold tracking-tight text-white">
                  The Education Process
                </h4>
              </div>
            </div>
            <div className="relative overflow-hidden rounded-lg shadow-lg cursor-pointer">
              <Image
                className="object-cover w-full h-48"
                src={developmentImage}
                alt={''}
              ></Image>
              <div className="absolute top-0 left-0 px-6 py-4">
                <h4 className="mt-10 pt-6 text-xl font-semibold tracking-tight text-white text-center">
                  The Development Phase
                </h4>
              </div>
            </div>
            <div className="relative overflow-hidden rounded-lg shadow-lg cursor-pointer col-span-2">
              <Image
                className="object-cover w-full h-48"
                src={growthRate}
                alt={''}
              ></Image>
              <div className="absolute top-0 left-0 px-6 py-4 text-white w-[100%] text-right">
                <h4 className="pt-6 text-xl font-semibold">20% Growth Rate</h4>
                <div className="font-light mt-5">
                  <p>180% Student Growth Rate</p>
                  <p>20% Fast Learning Track</p>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div>
          <p className="font-extrabold text-[#2B2A35] text-4xl my-10">
            <span className="font-lato text-[#264FAD]">
              The problems We Are{' '}
            </span>{' '}
            Solving
          </p>
          <ImagePragraph
            image={africaIcon}
            text={
              'Africa’s future depends on innovation. Transformative technologies\
              can drive rapid economic growth and lift millions of people out of\
              poverty. However, university computer science education is\
              misaligned with global market needs and fails to incorporate\
              practice-based learning, leaving students unable to apply their\
              skills in real-world contexts.'
            }
          />
          <ImagePragraph
            image={codingIcon}
            text={
              'With few global tech companies on the continent, aspiring engineers\
              don’t have access to experienced mentors, or the opportunity to work\
              on products that operate at scale. Smart and ambitious students who\
              could create life-changing technologies aren’t able to reach their\
              potential.'
            }
          />
        </div>
        <CenteredImage image={problemImage} />
        <CenteredImage image={howWeAreSolving} />

        <div>
          <p className="font-extrabold text-[#2B2A35] text-4xl my-10">
            How we are{' '}
            <span className="font-lato text-[#264FAD]">solving </span> it
          </p>

          <ImagePragraph
            image={lightIcon}
            text=" Offering students an ecosystem to actualize their ideas means that
            up-and-coming developers use their skills to benefit Africa, rather
            than taking their talent elsewhere."
          />
        </div>
        <p className="font-extrabold text-[#2B2A35] text-4xl my-10 col-span-2 text-center">
          <span className="font-lato text-[#264FAD]">Social </span> Projects
        </p>
        <div className="col-span-2">
          <SocialProject
            image={hakimHub}
            leftAligned={false}
            isImageLeft={true}
            title={'Hakim Hub'}
            content={
              'HakimHub is a platform that provides information about healthcare\
            facilities and healthcare professionals in Ethiopia. Hakimhub makes\
            information about hospitals, medical laboratories, and doctors\
            conveniently accessible to its users.'
            }
          />
          <div className="h-[50px]"></div>
          <SocialProject
            image={trackSys}
            leftAligned={true}
            isImageLeft={false}
            title={'Track Sym'}
            content={
              'TrackSym is a non-commercial app that uses crowd-sourcing to collect\
            and visualize the density of the relevant Covid-19 symptoms. Symptom\
            data, aggregated by places, can help people avoid visiting areas\
            that are heavily populated by symptomatic people.'
            }
          />
        </div>
      </div>
      <p className="font-extrabold text-[#2B2A35] text-4xl my-10 col-span-2 text-center">
        <span className="font-lato text-[#264FAD]">A2SV </span> Sessions
      </p>
      <div className="grid grid-cols-3 gap-2 bg-white text-size">
        <A2SVSession
          image={weeklyContests}
          title={'Bi-weekly contests'}
          content={
            'Contests help us to get better at competitive programming and\
            problem-solving. We use online platforms like Leetcode and\
            Codeforces.'
          }
        />
        <A2SVSession
          image={technicalTraining}
          title={'Technical Training'}
          content={
            '6 days a week, 3 hours of lectures and practice sessions to improve \
            technical problem-solving skills.'
          }
        />
        <A2SVSession
          image={qAndA}
          title={'Q&As'}
          content={
            'In Q&As, we get to know engineers, founders, and entrepreneurs from \
            top tech companies. We see that they are normal people like us and \
            we learn the best practices.'
          }
        />
        <A2SVSession
          image={problemSolvingSession}
          title={'Problem Solving Sessions'}
          content={
            'We solve technical problems on a whiteboard while explaining to the \
            class. It helps to get a feel of an interview environment.'
          }
        />
        <A2SVSession
          image={howToApproach}
          title={'Learn How to Approach Sessions'}
          content={
            ' Students observe how an experienced problem solver approaches a\
            problem from understanding it to implementing a working solution.'
          }
        />
        <A2SVSession
          image={weeklyOneOnOnes}
          title={'Bi-weekly 1-1s'}
          content={
            'In 1:1s, we can talk about anything that matters; clearly no \
            boundaries. The more we speak our minds without a filter, the better \
            for the team.'
          }
        />
      </div>
    </div>
  )
}

export default AboutPage
