import 'package:dark_knights/article_injection.dart';
import 'package:get_it/get_it.dart';

import 'user_injection_container.dart';

final sl = GetIt.instance;

Future<void> init() async{
  //! Features - Number Trivia
  await userDependencyInjection();
  await articleDependencyInjection();
  
  //! Core

  //! External

}

