import Select, { MultiValue } from 'react-select';

// tag options
export interface TagOption {
  value: string;
  label: string;
}

const tagOptions: TagOption[] = [
  { value: "Development", label: "Development" },
  { value: "Sports", label: "Sports" },
  { value: "Writing", label: "Writing" },
  { value: "Self Improvement", label: "Self Improvement" },
  { value: "Technology", label: "Technology" },
  { value: "Social", label: "Social" },
  { value: "Data Science", label: "Data Science" },
  { value: "Programming", label: "Programming" }
];

interface SelectBlogTagProps {
  selectedTags: MultiValue<TagOption>;
  onChange: (selectedOptions: MultiValue<TagOption>) => void;
}

const SelectBlogTag: React.FC<SelectBlogTagProps> = ({ selectedTags, onChange }) => {
  const handleTagChange = (selectedOptions: MultiValue<TagOption>): void => {
    if (selectedOptions) {
      onChange(selectedOptions);
    } else {
      onChange([]);
    }
  };

  return (
    <div>
      <h2 className="text-xl font-bold mb-4">Select Tag</h2>
      <Select
        isMulti
        name="tags"
        options={tagOptions}
        className="select-tag"
        classNamePrefix="select-tag"
        value={selectedTags}
        onChange={handleTagChange}
      />
    </div>
  );
};

export default SelectBlogTag;