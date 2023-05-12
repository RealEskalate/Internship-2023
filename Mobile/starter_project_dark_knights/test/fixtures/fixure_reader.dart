import 'dart:io';

import 'package:dark_knights/features/Authentication/domain/entities/authentication_entitiy.dart';

String fixture(String name) => File('test/fixtures/$name').readAsStringSync();