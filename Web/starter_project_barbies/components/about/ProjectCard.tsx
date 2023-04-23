import { ProjectCardProps } from '@/types/AboutTypes'
import Image from 'next/image'

const ProjectCard = ({ project, isEven }: ProjectCardProps) => {
  return (
    <div
      className={`flex flex-wrap justify-around ${
        !isEven ? 'flex-row-reverse' : ''
      }`}
    >
      <Image
        className="flex-initial"
        src={project.image}
        width={700}
        height={200}
        alt="hakimhub"
      />
      <div className={`mx-5 ${isEven ? 'lg:text-right' : 'lg:text-left'}`}>
        <div className="text-blue-600">Social Project</div>
        <div className="text-blue-600 font-bold text-3xl mt-2 mb-5">
          {project.project}
        </div>
        <div className="lg:max-w-sm text-gray-600">{project.description}</div>
        <div
          className={`flex gap-5 mt-5 ${
            isEven ? 'lg:justify-end' : 'lg:justify-start'
          }`}
        >
          <Image
            className="flex-initial"
            src="/about/github.svg"
            width={20}
            height={20}
            alt="github"
          />
          <Image
            className="flex-initial"
            src="/about/open.svg"
            width={20}
            height={20}
            alt="open in new tab"
          />
        </div>
      </div>
    </div>
  )
}

export default ProjectCard
