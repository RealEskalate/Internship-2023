import React from 'react'
import { Blog } from '../../types/blog'
import { MdOutlineModeComment } from 'react-icons/md'

import {
  AiFillClockCircle,
  AiFillCheckCircle,
  AiFillWarning,
} from 'react-icons/ai'

interface Props {
  card: Blog
  feature: string
}

const BlogCard: React.FC<Props> = ({ card, feature }) => {
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
    <div className="card w-[400px] font-montserrat flex flex-col border border-gray-300 rounded-lg overflow-hidden shadow-md bg-white h-543 my-8 font-bold">
      <img
        className="w-full h-60 object-cover"
        src={card.photoUrl}
        alt={`${card.writter.firstName} ${card.writter.lastName}`}
      />
      <div className="p-4">
        <b>
          <h2 className="card_title font-bold text-lg text-gray-700 break-words overflow-hidden line-clamp-3 leading-snug">
            {card.title}
          </h2>
        </b>

        <div className="card_writter flex items-center mb-6 mt-4">
          <img
            className="card_writter_image w-10 h-10 object-cover rounded-full mr-2"
            src={card.writter.photoUrl}
            alt={`${card.writter.firstName} ${card.writter.lastName}`}
          />

          <div className="card_writter_details flex flex-col items-start">
            <span className="card_writter_name m-0   text-gray-600 leading-5">
              <b className="font-thin">&nbsp;{' by '}</b>&nbsp;
              <b>
                {card.writter.firstName} {card.writter.lastName}
              </b>
              <b className="font-thin">
                &nbsp;&nbsp;{' | '}&nbsp;&nbsp;
                {new Date(card.dateOfCreation).toLocaleDateString('en-US', {
                  month: 'short',
                  day: 'numeric',
                  year: 'numeric',
                })}
              </b>
            </span>
          </div>
        </div>
        <div className="card_tags flex flex-row items-center mb-4">
          {card.tags.map((tag, index) => (
            <span
              key={index}
              className="card_tag mr-2 px-2 py-1 bg-gray-100 text-gray-500 rounded-full text-xs"
            >
              {tag}
            </span>
          ))}
        </div>
        <p className="card_description mt-3 mb-3 text-sm font-thin text-gray-500 break-words overflow-hidden line-clamp-3 leading-snug">
          {card.description}
        </p>
        <br />
        <hr className="line border-gray-200" />
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
      </div>
    </div>
  )
}

export default BlogCard
