+(float)getNativeScaleFactor
{
    UIScreen* uiScreen = [UIScreen mainScreen];
    return uiScreen.nativeScale;
}

@end

extern "c"
{
  float _GetNativeScaleFactor()
 {
    return [KizunaApplePlugin getNativeScaleFactor];
 }


}