import { Projects } from '@/data/about'
import ProjectCard from './ProjectCard'

const ProjectList = ({}) => {
  return (
    <div>
      <div className="font-bold lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl text-center mx-auto mb-12">
        Social <span className="text-blue-500">Projects</span>
      </div>
      <div className="flex flex-col gap-5">
        {Projects.map((project, index) => (
          <ProjectCard key={index} isEven={index % 2 === 0} project={project} />
        ))}
      </div>
    </div>
  )
}

export default ProjectList
