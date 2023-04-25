import { Blog } from "@/types/blog"

interface BlogContentProps {
  content: Blog['content']
}

export const BlogContent: React.FC<BlogContentProps> = ({ content }) => {
  // Split content into paragraphs
  let paragraphs = []
  let key = 0
  for (let line of content.split('\n')) {
    let paragraph = <p key={key++} className={`${'mt-6 ' + ((key == 1) ? ('text-xl font-french-cannon') : ('text-sm font-thin font-montserrat'))}`}>
      {line}
    </p>
    paragraphs.push(paragraph)
  }

  return (
    <div className='mx-96'>
      {paragraphs}
    </div>
  )
}
