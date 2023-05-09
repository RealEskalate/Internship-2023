import HeroSection from '../../components/about/HeroSection'
import ProblemsSection from '../../components/about/ProblemsSection'
import ProjectsList from '../../components/about/ProjectsList'
import SessionsList from '../../components/about/SessionsList'

const About = () => {
  return (
    <div className="flex flex-col gap-44 my-12">
      <HeroSection />

      <ProblemsSection />

      <ProjectsList />

      <SessionsList />
    </div>
  )
}

export default About
