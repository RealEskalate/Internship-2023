import 'package:matador/features/login/Domain/entities/user.dart';

import '../models/login_model.dart';

abstract class LoginUserLocalDataSource {
  Future<LoginModel> authenticate(User user);
}
