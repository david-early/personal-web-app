export interface UserInfo {
    identityProvider: string;
    userId: string;
    userDetails: string;
    userRoles: string[];
}

export const identityProviders = [
    "Github"
]