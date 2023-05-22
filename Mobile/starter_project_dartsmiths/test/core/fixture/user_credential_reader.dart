import 'dart:io';

String fixture(String file) {
  return File("test\\core\\fixture\\$file").readAsStringSync();
}
