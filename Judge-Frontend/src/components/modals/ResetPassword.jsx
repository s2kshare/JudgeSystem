import { Dialog, DialogPanel, DialogTitle } from '@headlessui/react';
import NiceModal, { useModal } from '@ebay/nice-modal-react';
import { RxCross2, RxCheck } from 'react-icons/rx';
import { useState, useEffect } from 'react';

export default NiceModal.create(({}) => {
    const modal = useModal();

    // State Management
    const [password, setPassword] = useState('');
    const [passwordConfirmation, setPasswordConfirmation] = useState('');
    const [passwordValidity, setPasswordValidity] = useState(false); // State to track if all requirements are valid

    // List of requirements
    const requirements = [
        { id: 1, text: 'At least 8 characters', isValid: password.length >= 8 },
        { id: 2, text: 'One lowercase letter', isValid: /[a-z]/.test(password) },
        { id: 3, text: 'One uppercase letter', isValid: /[A-Z]/.test(password) },
        { id: 4, text: 'One number', isValid: /[0-9]/.test(password) },
    ];

    // Update password validity whenever password or requirements change
    useEffect(() => {
        const allRequirementsMet = requirements.every((req) => req.isValid);
        setPasswordValidity(allRequirementsMet);
    }, [password]);

    // Handle input changes
    const handlePasswordChange = (event) => setPassword(event.target.value);
    const handlePasswordConfirmationChange = (event) => setPasswordConfirmation(event.target.value);

    // Handle password change submission logic
    const handleSubmit = () => {
        if (passwordValidity && password === passwordConfirmation) {
            modal.hide();
        }
    };

    return (
        <Dialog
            transition={true}
            open={modal.visible}
            onClose={() => {
                modal.hide();
            }}
            as="div"
            className="relative z-10 focus:outline-none"
        >
            <div className="fixed inset-0 z-10 w-screen overflow-y-auto">
                <div className="flex min-h-full items-center justify-center p-4">
                    <DialogPanel
                        transition
                        className="w-full max-w-2xl rounded-xl bg-white/5 p-6 backdrop-blur-2xl duration-300 ease-out"
                    >
                        <DialogTitle as="h3" className="text-base/7 text-center font-medium text-white mb-[1rem]">
                            Reset Password
                        </DialogTitle>
                        <div className="flex">
                            <div className="left-panel">
                                <p className="mt-2 text-sm/6 text-white/50">
                                    This is where you can reset your password.
                                    <br />
                                    <span className="text-xs">Password must contain:</span>
                                </p>
                                <ul className="text-xs select-none">
                                    {requirements.map((requirement) => (
                                        <li
                                            key={requirement.id}
                                            className={`flex gap-1 items-center ${
                                                requirement.isValid ? 'text-success' : 'text-error'
                                            }`}
                                        >
                                            {requirement.isValid ? <RxCheck /> : <RxCross2 />} {requirement.text}
                                        </li>
                                    ))}
                                </ul>
                            </div>
                            <div className="right-panel flex-1 ml-[2rem] flex flex-col">
                                <label className="form-control w-full">
                                    <div className="label">
                                        <span className="label-text">Enter new password</span>
                                    </div>
                                    <input
                                        type="password"
                                        placeholder="Type here"
                                        className="input input-bordered w-full"
                                        value={password}
                                        onChange={handlePasswordChange}
                                    />
                                </label>
                                <label className="form-control w-full">
                                    <div className="label">
                                        <span className="label-text">Enter new password again</span>
                                    </div>
                                    <input
                                        type="password"
                                        placeholder="Type here"
                                        className="input input-bordered w-full"
                                        value={passwordConfirmation}
                                        onChange={handlePasswordConfirmationChange}
                                    />
                                </label>
                                <button
                                    className="btn mt-4"
                                    onClick={handleSubmit}
                                    disabled={!passwordValidity || password !== passwordConfirmation}
                                >
                                    Submit
                                </button>
                            </div>
                        </div>
                    </DialogPanel>
                </div>
            </div>
        </Dialog>
    );
});
