import React, {ReactNode} from "react";

const TeamMemberCardShimmer: React.FC = ()=> {
    return (
        <div className="box-content font-sans w-72 mt-4 text-center shadow-md shadow-gray-200 rounded-md py-2 m-auto">
            <div className="rounded-full mx-auto w-32 bg-gray-300 animate-pulse" style={{ width: 200, height: 300 }}></div>

            <div className="m-4">
                <h3 className="text-2xl m-3 font-extrabold tracking-widest uppercase bg-gray-300 h-6 animate-pulse"></h3>
                <p className="m-3 tracking-widest text-base uppercase bg-gray-300 h-4 animate-pulse"></p>
                <p className="text-sm mt-5 mb-3 text-secondarytext font-light px-4 tracking-wide bg-gray-300 h-10 animate-pulse"></p>
            </div>

            <hr className="h-0.5 border-t-0 bg-neutral-100 opacity-100 dark:opacity-50 block m-auto w-5/6" />

            <div className="flex-row mt-3">
                <div className="inline-block bg-gray-300 w-16 h-16 mx-2">
                </div>
                <div className="inline-block bg-gray-300 w-16 h-16 mx-2">
                </div>
                <div className="inline-block  bg-gray-300 w-16 h-16 mx-2">
                </div>
            </div>
        </div>
    );
};

export default TeamMemberCardShimmer;