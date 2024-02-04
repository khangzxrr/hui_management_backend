namespace hui_management_backend.Web.Constants;

public class ResponseMessageConstants
{
  public const string WrongPhoneNumerOrPassword = "WRONG_PHONE_NUMBER_OR_PASSWORD";


  public const string OwnerNotFound = "OWNER_NOT_FOUND";

  public const string FundNotFound = "FUND_NOT_FOUND";
  public const string UserNotFound = "USER_NOT_FOUND";
  public const string FundMemberNotFound = "FUND_MEMBER_NOT_FOUND";
  public const string SessionNotFound = "SESSION_NOT_FOUND";

  public const string FundMemberAlreadyTakenFund = "FUND_MEMBER_ALREADY_TAKEN_FUND";

  public const string FundIsStarted = "FUND_IS_STARTED";

  public const string FundIsNotContainAnyUser = "FUND_NOT_CONTAIN_ANY_USER";


  public const string FundNotContainUser = "FUND_NOT_CONTAIN_USER";

  public const string PaymentNotFound = "PAYMENT_NOT_FOUND";
  public const string PaymentIsFinished = "PAYMENT_IS_FINISHED";
  public const string PaymentIsNotBelongToUser = "PAYMENT_IS_NOT_BELONG_TO_USER";

  public const string UserIsNotBelongToFundOwner = "USER_IS_NOT_BELONG_TO_FUND_OWNER";

  public const string TransactionMethodCannotBeParsed = "TRANSACTION_METHOD_CANNOT_BE_PARSED";

  public const string FileExtensionNotExist = "FILE_EXTENSION_NOT_EXIST";
  public const string FileExtensionNotSupport = "FILE_EXTENSION_NOT_SUPPORT";
  public const string FirebaseKeyNotExist = "FIREBASE_KEY_NOT_EXIST";

  public const string MediaNotFound = "MEDIA_NOT_FOUND";

  public const string SubUserIsNotFound = "SUB_USER_IS_NOT_FOUND";
  public const string SubUserAlreadyExist = "SUB_USER_ALREADY_EXIST";

  public const string NoSubUserInfoYet = "NO_SUB_USER_INFO_YET";

  public const string UserHasBillsOrAttendInFunds = "USER_HAS_BILLS_OR_ATTEND_IN_FUNDS";

  public const string CannotParseFundType = "CANNOT_PARSE_FUND_TYPE";

  public const string FundNotHaveSessionYet = "FUND_NOT_HAVE_ANY_SESSION_YET";

  public const string FundIsEnded = "FUND_IS_ENDED";

  public const string SessionNotHaveTakenSessionDetail = "SESSION_NOT_HAVE_TAKEN_SESSION_DETAIL";

  public const string TodayPaymentIsNotFound = "TODAY_PAYMENT_IS_NOT_FOUND";
  public const string CannotParseCustomBillType = "CANNOT_PARSE_CUSTOM_BILL_TYPE";
}
