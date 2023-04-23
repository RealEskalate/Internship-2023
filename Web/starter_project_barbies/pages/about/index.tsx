import HeroSection from '../../components/about/HeroSection'
import ProblemSection from '../../components/about/ProblemSection'
import ProjectList from '../../components/about/ProjectList'
import SessionList from '../../components/about/SessionList'

const About = () => {
  return (
    <div className="flex flex-col gap-44 my-12">
      <HeroSection />

      <ProblemSection />

      <ProjectList />

      <SessionList />
    </div>
  )
}

export default About
