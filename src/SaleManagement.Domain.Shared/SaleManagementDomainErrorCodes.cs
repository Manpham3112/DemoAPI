namespace SaleManagement
{
    public static class SaleManagementDomainErrorCodes
    {
        /* You can add your business exception error codes here, as constants */

        public const int USERNAME_PASSWORD_IS_NOT_CORRECT = 1000;
        public const int ACCOUNT_IS_LOCKED = 1001;
        public const int CREATE_USER_FAILED = 1002;
        public const int USERNAME_IS_TAKEN = 1003;
        public const int EMAIL_IS_TAKEN = 1004;
        public const int PHONE_NUMBER_IS_TAKEN = 1005;

        public const int PRODUCT_NAME_IS_TAKEN = 2000;
        public const int PRODUCT_NOT_FOUND = 2001;

        public const int ROOM_NAME_IS_TAKEN = 2000;
        public const int ROOM_NOT_FOUND = 2001;
    }
}
