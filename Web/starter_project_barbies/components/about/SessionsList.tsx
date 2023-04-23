import { sessions } from '@/data/about'
import { Session } from '@/types/about'
import { IconContext } from 'react-icons'

interface SessionCardProps {
  session: Session
}

const SessionCard: React.FC<SessionCardProps> = ({ session }) => {
  return (
    <div className="rounded-lg border-gray-200 border-2 px-10 py-5">
      <div>
        <IconContext.Provider
          value={{
            className:
              'text-white bg-gradient-to-tr from-blue-500 via-purple-500 to-purple-900  rounded-full p-4',
            size: '4em',
          }}
        >
          {session.icon}
        </IconContext.Provider>
      </div>

      <div className="font-bold my-2">{session.session}</div>
      <div>{session.description}</div>
    </div>
  )
}

const SessionsList = ({}) => {
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
