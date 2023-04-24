import { Blog } from "@/types/blog";

interface TagListProps {
  tags: Blog['tags']
}

export const TagList: React.FC<TagListProps> = ({ tags }) => {
  let tagComponents = []
  for (let tag of tags) {
    tagComponents.push(<Tag tag={tag} />)
  }

  return (
    <div className="flex gap-2">
      {tagComponents}
    </div>
  )
}

interface TagProps {
  tag: string
}

const Tag: React.FC<TagProps> = ({ tag }) => {
  return (
    <div className="text-xs font-extralight bg-gray-100 rounded-full px-8 py-2">
      {tag}
    </div>
  )
}
