import A2SVSession from '@/components/about/A2SVSession'
import Activities from '@/components/about/Activities'
import CenteredImage from '@/components/about/CenteredImage'
import ImagePragraph from '@/components/about/ImagePragraph'
import SocialProject from '@/components/about/SocialProject'
import React from 'react'
import { a2svSessions } from '../../data/about/a2sv-sessions'
import { socialProjects } from '../../data/about/social-projects'
import africaIcon from '../../public/img/about/icons/africa-icon.svg'
import codingIcon from '../../public/img/about/icons/coding-icon.svg'
import lightIcon from '../../public/img/about/icons/light-icon.svg'
import howWeAreSolving from '../../public/img/about/problems/how-we-are-solving.svg'
import problemImage from '../../public/img/about/problems/problem-image.svg'

const AboutPage: React.FC = () => {
  return (
    <div className="bg-white p-10">
      <div className="grid grid-cols-1 md:grid-cols-2 gap-10">
        <div>
          <p className="font-extrabold text-secondary text-4xl">
            <span className="text-primary">Africa </span> to Silicon Valley
          </p>
          <p className="py-7">
            A2SV is a social enterprise that enables high-potential university
            students to create digital solutions to Africa’s most pressing
            problems.
          </p>
          <button className="bg-primary hover:bg-blue-700 text-white font-bold py-3 px-7 rounded m-auto">
            Meet Our Team
          </button>
          <p className="py-7">
            A2SV is a social enterprise that enables high-potential university
            students to create digital solutions to Africa’s most pressing
            problems.
          </p>
        </div>
        <Activities
          studentGrowthRate={180}
          learningRate={100}
          growthRate={20}
        />
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-10">
        <div>
          <p className="font-extrabold text-secondary text-4xl my-10">
            <span className="font-lato text-primary">The Problem We </span> Are
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
      </div>
      <div className="grid grid-cols-1 md:grid-cols-2 gap-10">
        <CenteredImage image={howWeAreSolving} />

        <div>
          <p className="font-extrabold text-secondary text-4xl my-10">
            How we are <span className="text-primary">solving </span> it
          </p>

          <ImagePragraph
            image={lightIcon}
            text=" Offering students an ecosystem to actualize their ideas means that
    up-and-coming developers use their skills to benefit Africa, rather
    than taking their talent elsewhere."
          />
        </div>
      </div>
      <div className="grid grid-cols-2 gap-10">
        <p className="font-extrabold text-secondary text-4xl my-10 col-span-2 text-center">
          <span className="font-lato text-primary">Social </span> Projects
        </p>
        {socialProjects.map((project) => {
          return (
            <div className="col-span-2" key={project.title}>
              <SocialProject
                image={project.image}
                leftAligned={project.leftAligned}
                isImageLeft={project.isImageLeft}
                title={project.title}
                content={project.content}
              />
              <div className="h-[50px]"></div>
            </div>
          )
        })}
      </div>
      <p className="font-extrabold text-secondary text-4xl my-10 col-span-2 text-center">
        <span className="font-lato text-primary">A2SV </span> Sessions
      </p>
      <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-2 bg-white text-size">
        {a2svSessions.map((session) => {
          return (
            <A2SVSession
              image={session.image}
              title={session.title}
              content={session.content}
              key={session.title}
            />
          )
        })}
      </div>
    </div>
  )
}

export default AboutPage
