import BlogCard from '@/components/common/blogCard'
import { card1 } from '@/store/mockData/data'

const index = () => {
  const nums: number[] = [0, 1, 2, 3, 4]
  return (
    <div
      style={{
        display: 'flex',
        marginTop: '10px',
        flexDirection: 'row',
        justifyContent: 'flex-start',
        flexWrap: 'wrap',
        alignContent: 'flex-end',
      }}
    >
      {nums?.map((value, index) => {
        if (index % 2 === 0)
          return (
            <div style={{ marginLeft: '7px' }} key={value}>
              <BlogCard card={card1} feature="likes" />
            </div>
          )
        else
          return (
            <div style={{ marginLeft: '7px' }} key={value}>
              <BlogCard card={card1} feature="status" />
            </div>
          )
      })}
    </div>
  )
}

export default index
