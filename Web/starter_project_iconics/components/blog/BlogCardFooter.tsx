import { Blog } from '@/types/profile/blog'
import {
  AiFillCheckCircle,
  AiFillClockCircle,
  AiFillWarning,
} from 'react-icons/ai'
import { MdOutlineModeComment } from 'react-icons/md'

interface BlogFooterProps {
  card: Blog
  feature: string
}

const BlogFooter: React.FC<BlogFooterProps> = ({ card, feature }) => {
  const statusIcon = {
    approved: <AiFillCheckCircle size={18} />,
    declined: <AiFillWarning size={18} />,
    pending: <AiFillClockCircle size={18} />,
  }

  const abbreviations: [number, string][] = [
    [1e3, 'K'],
    [1e6, 'M'],
    [1e9, 'B'],
  ]
  return (
    <div>
      <div className="card_footer flex justify-between items-center">
        {(() => {
          if (feature === 'likes') {
            let val: string = ''
            for (const [value, abbreviation] of abbreviations) {
              if (card.likes >= value) {
                const roundedNum = (card.likes / value).toFixed(1)
                val = `${roundedNum}${abbreviation} likes`
              }
            }
            return (
              <span className="flex items-center">
                <span
                  className="card_writter_likes m-0 text-sm font-medium text-gray-500"
                  data-likes={card.likes}
                  style={{ display: 'inline-block', marginRight: '14px' }}
                >
                  <MdOutlineModeComment size={15} />
                </span>
                <span
                  className="card_writter_likes m-0 text-sm font-medium text-gray-500"
                  data-likes={card.likes}
                  style={{ display: 'inline-block' }}
                >
                  {val}
                </span>
              </span>
            )
          } else {
            return (
              <span className="flex items-center">
                {
                  <span
                    className={
                      card.status === 'approved'
                        ? 'text-green-600 '
                        : card.status === 'declined'
                        ? 'text-red-600 '
                        : 'text-orange-500 '
                    }
                    style={{
                      display: 'inline-block',
                      marginRight: '10px',
                    }}
                  >
                    {statusIcon[card.status || 'pending']}
                  </span>
                }
                <span
                  className={
                    card.status === 'approved'
                      ? 'text-green-600 text-sm'
                      : card.status === 'declined'
                      ? 'text-red-600 text-sm'
                      : 'text-orange-500 text-sm'
                  }
                  style={{ display: 'inline-block' }}
                >
                  {card.status.toUpperCase()}
                </span>
              </span>
            )
          }
        })()}

        <button className="card_read_more px-4 py-2 text-sm rounded-md border-none bg-white text-purple-500 font-bold cursor-pointer transition duration-200 ease-in-out">
          Read More
        </button>
      </div>
    </div>
  )
}

export default BlogFooter
