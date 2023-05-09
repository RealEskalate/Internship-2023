import { Session } from '@/types/about'
import Image from 'next/image'
import sessions from '../../data/about/sessions.json'

interface SessionCardProps {
  session: Session
}

const SessionCard: React.FC<SessionCardProps> = ({ session:{name, icon, description} }) => {
  return (
    <div className="rounded-lg border-gray-200 border-2 px-10 py-5">
      <Image className='my-5' src={`/img/about/sessions/${icon}`} width={50} height={50} alt='' />
      <div className="font-bold my-2">{name}</div>
      <div>{description}</div>
    </div>
  )
}

const SessionsList:React.FC = () => {
  return (
    <div>
      <div className="font-bold lg:text-5xl md:text-4xl sm:text-3xl xs:text-2xl text-center mx-auto mb-10">
        A2SV <span className="text-primary ">Sessions</span>
      </div>
      <div className="grid lg:grid-cols-3 gap-2 px-16 ">
        {sessions.map((session, index) => (
          <SessionCard key={index} session={session} />
        ))}
      </div>
    </div>
  )
}

export default SessionsList
