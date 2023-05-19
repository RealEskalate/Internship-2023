import React, { useState, useEffect } from 'react';

interface TagSelectionProps {
  tags: string[];
  onTagSelection: (tags: string[]) => void;
}

const TagSelection: React.FC<TagSelectionProps> = ({ tags, onTagSelection }) => {
  const [selectedTags, setSelectedTags] = useState<string[]>([]);

  // Function to handle tag selection
  const handleTagSelection = (tag: string) => {
    if (selectedTags.includes(tag)) {
      setSelectedTags(selectedTags.filter((selectedTag) => selectedTag !== tag));
    } else {
      setSelectedTags([...selectedTags, tag]);
    }
  };

  // Function to check if a tag is selected
  const isTagSelected = (tag: string) => selectedTags.includes(tag);

  // Function to handle tag button click
  const handleTagClick = (tag: string) => {
    handleTagSelection(tag);
  };

  // Call the onTagSelection callback whenever selectedTags change
  useEffect(() => {
    onTagSelection(selectedTags);
  }, [selectedTags, onTagSelection]);

  return (
    <div className="flex flex-wrap">
      {tags.map((tag) => (
        <button
          key={tag}
          className={`btn hover:bg-sky-600 hover:text-white ${
            selectedTags.includes(tag) ? 'btn-active' : ''
          } font-{montserrat} text-blog m-1 btn-outline text-sm  btn-sm btn-pill`}
          onClick={() => handleTagClick(tag)}
        >
          {tag}
        </button>
      ))}
    </div>
  );
};

export default TagSelection;
