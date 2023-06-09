import { BlogStatus } from '@/types/blog'
import {
  AiFillCheckCircle,
  AiFillClockCircle,
  AiFillWarning,
} from 'react-icons/ai'
import { MdOutlineModeComment } from 'react-icons/md'

interface BlogFooterProps {
  numberOfLikes: number
  blogStatus: BlogStatus
  pageName: 'MYBLOGS' | 'RELATEDBLOGS'
}

const BlogFooter: React.FC<BlogFooterProps> = ({
  numberOfLikes,
  blogStatus,
  pageName,
}) => {
  const statusIcon = {
    [BlogStatus.approved]: <AiFillCheckCircle size={18} />,
    [BlogStatus.declined]: <AiFillWarning size={18} />,
    [BlogStatus.pending]: <AiFillClockCircle size={18} />,
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
          if (pageName == 'MYBLOGS') {
            let val: string = ''
            for (const [value, abbreviation] of abbreviations) {
              if (numberOfLikes >= value) {
                const roundedNum = (numberOfLikes / value).toFixed(1)
                val = `${roundedNum}${abbreviation} likes`
              }
            }
            return (
              <span className="flex items-center">
                <span
                  className="card_writter_likes m-0 text-sm font-medium text-gray-500"
                  data-likes={numberOfLikes}
                  style={{ display: 'inline-block', marginRight: '14px' }}
                >
                  <MdOutlineModeComment size={15} />
                </span>
                <span
                  className="card_writter_likes m-0 text-sm font-medium text-gray-500"
                  data-likes={numberOfLikes}
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
                      blogStatus === BlogStatus.approved
                        ? 'text-green-600 '
                        : blogStatus === BlogStatus.declined
                        ? 'text-red-600 '
                        : 'text-orange-500 '
                    }
                    style={{
                      display: 'inline-block',
                      marginRight: '10px',
                    }}
                  >
                    {statusIcon[blogStatus || BlogStatus.pending]}
                  </span>
                }
                <span
                  className={
                    blogStatus === BlogStatus.approved
                      ? 'text-green-600 text-sm'
                      : blogStatus === BlogStatus.declined
                      ? 'text-red-600 text-sm'
                      : 'text-orange-500 text-sm'
                  }
                  style={{ display: 'inline-block' }}
                >
                  {blogStatus}
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
