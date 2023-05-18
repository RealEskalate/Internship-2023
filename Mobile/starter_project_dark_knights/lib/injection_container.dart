import 'package:dark_knights/user_injection_container.dart';
import 'package:get_it/get_it.dart';

final sl = GetIt.instance;

Future<void> init() async {
  //! Features - User
  await userDependencyInit();

  //! Core

  //! External
}
