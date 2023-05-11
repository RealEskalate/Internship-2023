import projects from '@/data/about/projects.json'
import { Project } from '@/types/about'
import Image from 'next/image'
import { IconContext } from 'react-icons'
import { FiGithub } from 'react-icons/fi'
import { IoMdOpen } from 'react-icons/io'

interface ProjectCardProps {
  project: Project
  reverseFlex: boolean
}
const ProjectCard: React.FC<ProjectCardProps> = ({ project:{image, name, description}, reverseFlex }) => {
  return (
    <div
      className={`flex flex-wrap justify-around ${
        reverseFlex ? 'flex-row-reverse' : ''
      }`}
    >
      <Image
        className="flex-initial"
        src={`/img/about/projects/${image}`}
        style={{width:'auto', height:'auto'}}
        width={700}
        height={200}
        alt=""
      />
      <div
        className={`mx-5 ${!reverseFlex ? 'lg:text-right' : 'lg:text-left'}`}
      >
        <div className="text-primary">Social Project</div>
        <div className="text-primary font-bold text-3xl mt-2 mb-5">
          {name}
        </div>
        <div className="lg:max-w-sm text-gray-600">{description}</div>
        <div
          className={`flex gap-5 mt-5 ${
            !reverseFlex ? 'lg:justify-end' : 'lg:justify-start'
          }`}
        >
          <IconContext.Provider value={{ className: 'text-primary' }}>
            <FiGithub size="1.25em" />
          </IconContext.Provider>
          <IconContext.Provider value={{ className: 'text-primary' }}>
            <IoMdOpen size="1.25em" />
          </IconContext.Provider>
        </div>
      </div>
    </div>
  )
}

const ProjectsList:React.FC = () => {
  return (
    <div>
      <div className="font-bold lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl text-center mx-auto mb-12">
        Social <span className="text-primary">Projects</span>
      </div>
      <div className="flex flex-col gap-5">
        {projects.map((project, index) => (
          <ProjectCard
            key={index}
            reverseFlex={index % 2 !== 0}
            project={project}
          />
        ))}
      </div>
    </div>
  )
}

export default ProjectsList
