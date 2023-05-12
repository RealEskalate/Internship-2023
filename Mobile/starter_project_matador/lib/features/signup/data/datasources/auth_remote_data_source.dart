import '../models/user_model.dart';

abstract class AuthRemoteDataSource {
  Future<UserModel> signUp(String email, String password);
}
