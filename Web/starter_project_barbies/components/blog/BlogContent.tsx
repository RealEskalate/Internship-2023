import { Blog } from "@/types/blog"

interface BlogContentProps {
  content: Blog['content']
}

export const BlogContent: React.FC<BlogContentProps> = ({ content }) => {
  // Split content into paragraphs
  let paragraphs = content.split('\n').map((line, index) => (
    <p key={index} className={`${'mt-6 ' + ((index == 0) ? ('text-xl font-french-cannon') : ('text-sm font-thin font-montserrat'))}`}>
      {line}
    </p>
  ))

  return (
    <div className='mx-96'>
      {paragraphs}
    </div>
  )
}
