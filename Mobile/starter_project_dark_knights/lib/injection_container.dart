import 'package:dark_knights/article_injection_container.dart';
import 'package:get_it/get_it.dart';

import 'user_injection_container.dart';

final sl = GetIt.instance;

Future<void> init() async{
  //! Features - User
  await userInjectionInit();

  //! Features - Article
  await articleInjectionInit();

  //! Core

  //! External

}

