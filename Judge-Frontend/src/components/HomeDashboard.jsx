import HomeUserStats from './HomeUserStats';
import ResetPassword from './modals/ResetPassword';

function HomeDashboard() {
    return (
        <div className="bg-base-200 p-10">
            <div className="w-full">
                <div className="flex flex-col md:flex-row w-full justify-between gap-10 md:gap-2">
                    <div className="flex items-center">
                        <div className="">
                            <h1 className="text-5xl font-bold">Dashboard</h1>
                            <p>
                                Welcome to the <b>Judge System</b>
                            </p>
                            <p>
                                This is where lab submissions can be both submitted and viewed for <b>you</b>, the user.
                            </p>
                        </div>
                    </div>
                    <div className="user-statistics flex items-center justify-center md:justify-end">
                        <div className="user-stats-holder">
                            <h3 className=" font-semibold">Statistics</h3>
                            <HomeUserStats />
                        </div>
                    </div>
                    <div className="user-graphs flex flex-col gap-5 md:items-end items-center">
                        <h1 className="text-center font-semibold">Work Completed</h1>
                        <div
                            className="radial-progress"
                            style={{ '--value': '90', '--size': '8rem', '--thickness': '2px' }}
                            role="progressbar"
                        >
                            70%
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default HomeDashboard;
