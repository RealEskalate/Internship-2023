import React, { ReactElement } from 'react'
import styles from '../../styles/blogCard.module.css'
import { Blog } from '../../types/models'
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
  const handleReadMore = () => {
    console.log('Read More button clicked')
  }
  const statusIcons: ReactElement[] = [
    <AiFillCheckCircle key={1} size={20} className={styles.statIcon} />,
    <AiFillWarning key={2} size={20} className={styles.statIcon} />,
    <AiFillClockCircle key={3} size={20} className={styles.statIcon} />,
  ]
  const statusToNum: (stat: string) => number = (stat) => {
    if (stat === 'approved') return 0
    if (stat === 'denied') return 1
    return 2
  }
  const formatNumber: (num: number) => string | number = (num: number) => {
    if (num >= 1000000000) {
      return (num / 1000000000).toFixed(1) + 'B'
    } else if (num >= 1000000) {
      return (num / 1000000).toFixed(1) + 'M'
    } else if (num >= 1000) {
      return (num / 1000).toFixed(1) + 'K'
    } else {
      return num
    }
  }
  return (
    <div className={styles.card}>
      <img
        className={styles.card_image}
        src={card.photoUrl}
        alt={`${card.writter.firstName} ${card.writter.lastName}`}
      />
      <div className={styles.card_content}>
        <h2 className={styles.card_title}>{card.title}</h2>

        <div className={styles.card_writter}>
          <img
            className={styles.card_writter_image}
            src={card.writter.photoUrl}
            alt={`${card.writter.firstName} ${card.writter.lastName}`}
          />

          <div className={styles.card_writter_details}>
            <span className={styles.card_writter_name}>
              <b className={styles.by}>&nbsp;{' by '}</b>&nbsp;
              {card.writter.firstName} {card.writter.lastName}
              <b className={styles.by}>
                &nbsp;&nbsp;{' | '}&nbsp;&nbsp;
                {new Date(card.dateOfCreation).toLocaleDateString()}
              </b>
            </span>
          </div>
        </div>
        <div className={styles.card_tags}>
          {card.tags.map((tag, index) => (
            <span key={index} className={styles.card_tag}>
              {tag}
            </span>
          ))}
        </div>
        <p className={styles.card_description}>{card.description}</p>
        <br />
        <hr className={styles.line} />
        <div className={styles.card_details}>
          <div className={styles.card_footer}>
            {(() => {
              if (feature === 'likes') {
                return (
                  <span style={{ display: 'flex', alignItems: 'center' }}>
                    <span
                      className={styles.card_writter_likes}
                      data-likes={card.likes}
                      style={{ display: 'inline-block', marginRight: '14px' }}
                    >
                      <MdOutlineModeComment size={15} />
                    </span>
                    <span
                      className={styles.card_writter_likes}
                      data-likes={card.likes}
                      style={{ display: 'inline-block' }}
                    >
                      {formatNumber(card.likes)} likes
                    </span>
                  </span>
                )
              } else {
                return (
                  <span style={{ display: 'flex', alignItems: 'center' }}>
                    {
                      <span
                        className={
                          card.status === 'approved'
                            ? styles.card_status_approved
                            : card.status === 'declined'
                            ? styles.card_status_declined
                            : styles.card_status_pending
                        }
                        style={{
                          display: 'inline-block',
                          marginRight: '14px',
                        }}
                      >
                        {statusIcons[statusToNum(card.status)]}
                      </span>
                    }
                    <span
                      className={
                        card.status === 'approved'
                          ? styles.card_status_approved
                          : card.status === 'declined'
                          ? styles.card_status_declined
                          : styles.card_status_pending
                      }
                      style={{ display: 'inline-block' }}
                    >
                      {card.status.toUpperCase()}
                    </span>
                  </span>
                )
              }
            })()}

            <button className={styles.card_read_more} onClick={handleReadMore}>
              Read More
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}

export default BlogCard
