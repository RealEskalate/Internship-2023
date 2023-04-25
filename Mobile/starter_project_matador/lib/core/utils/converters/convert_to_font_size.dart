import 'dart:math';
// converts to fontSize given screen width and screen height of design fonts

double convertToFontSize({required double height, required double width}) {
  return (sqrt(height * 0.25 + width * 0.75) * 4);
}
