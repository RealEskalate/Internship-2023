// import react-select library
import Select from 'react-select';

// tag options
const tagOptions = [
  { value: "Development", label: "Development" },
  { value: "Sports", label: "Sports" },
  { value: "Writing", label: "Writing" },
  { value: "Self Improvement", label: "Self Improvement" },
  { value: "Technology", label: "Technology" },
  { value: "Social", label: "Social" },
  { value: "Data Science", label: "Data Science" },
  { value: "Programming", label: "Programming" }
];

const SelectBlogTag: React.FC = () => {
  return (
    <div>
        <h2 className="text-xl font-bold mb-4">Select Tag</h2>
      <Select
        isMulti
        name="tags"
        options={tagOptions}
        className="select-tag"
        classNamePrefix="select-tag"
      />
    </div>
  );
};

export default SelectBlogTag;
