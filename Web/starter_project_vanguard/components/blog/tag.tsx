import { FC } from "react";

type ChipProps = {
  label: string;
};

const Chip: FC<ChipProps> = ({ label }) => {
  return (
    <div className="flex items-center px-4 py-3 rounded-full bg-gray-200 text-gray-400 mr-2 mb-2 mx-4 mt-5 ">
      <div className="text-md font-medium">{label}</div>
    </div>
  );
};

export default Chip;
