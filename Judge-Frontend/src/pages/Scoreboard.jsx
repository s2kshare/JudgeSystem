import ScoreboardCard from '../components/ScoreboardCard';

function Scoreboard() {
    return (
        <div className="flex w-full flex-col border-opacity-50">
            <div className="header flex items-center justify-center py-10 bg-base-200">
                <div>
                    <h1 className="text-center font-bold text-5xl">Scoreboard</h1>
                    <p className="text-center">This is where all students can see the leaderboard</p>
                    <select className="select select-bordered w-full max-w-xs">
                        <option>Han Solo</option>
                        <option>Greedo</option>
                    </select>
                </div>
            </div>
            <div className="divider"></div>
            <div className="flex flex-col mx-40 pb-10">
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
                <ScoreboardCard />
            </div>
        </div>
    );
}

export default Scoreboard;
