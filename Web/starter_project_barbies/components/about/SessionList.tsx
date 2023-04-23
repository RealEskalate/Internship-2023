import { Sessions } from '@/data/about'
import SessionCard from './SessionCard'

const SessionList = ({}) => {
  return (
    <div>
      <div className="font-bold lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl text-center mx-auto mb-10">
        A2SV <span className="text-blue-500 ">Sessions</span>
      </div>
      <div className="grid lg:grid-cols-3 gap-2 px-16 ">
        {Sessions.map((session, index) => (
          <SessionCard key={index} session={session} />
        ))}
      </div>
    </div>
  )
}

export default SessionList
