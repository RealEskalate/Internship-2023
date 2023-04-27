import { FC } from "react";
import Chip from "./tag";

type MyComponentProps = {
  tags: string[];
};

const Tags: FC<MyComponentProps> = ({ tags }) => {
  return (
    <div className="flex flex-wrap justify-start items-end">
      {tags.map((tag, index) => (
        <Chip key={index} label={tag}  />
      ))}
    </div>
  );
};

export default Tags;
