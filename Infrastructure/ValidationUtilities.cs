using JetBrains.Annotations;

namespace MedHubCompany.Extensions.Vidal.Infrastructure;

/// <summary>
/// Provides utilities for validating data.
/// </summary>
public static class ValidationUtilities
{
    private const byte Cip13Length = 13;
    private const byte Cip7Length = 7;

    /// <summary>
    /// Validates the syntax for a given CIP13, a package's unique identifier.
    /// </summary>
    /// <remarks>
    /// The CIP13 / UCD13 follows a distinct pattern :
    /// <para>
    ///   <list type="table">
    ///     <listheader>
    ///       <term>#</term>
    ///       <description>Description</description>
    ///     </listheader>
    /// 
    ///     <item>
    ///       <term><c>1..4</c></term>
    ///       <description>Always <c>3400</c> for CIP13, or <c>3401</c> for ACL13.</description>
    ///     </item>
    /// 
    ///     <item>
    ///       <term><c>5..12</c></term>
    ///       <description>Unique identifier of the package (aka <see cref="Cip7">CIP7</see>).</description>
    ///     </item>
    /// 
    ///     <item>
    ///       <term><c>13</c></term>
    ///       <description>Checksum digit.</description>
    ///     </item>
    ///   </list>
    /// </para>
    /// </remarks>
    /// <param name="cip13">The CIP13 to validate.</param>
    /// <param name="strict">Whether to validate the CIP13 strictly (disallow UCD/ACL variants).</param>
    /// <returns><see langword="true"/> if the CIP13 is valid; otherwise, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsValidCip13(this long cip13, bool strict = false) => strict 
        ? cip13 is > 3400_0_0000000_0 and < 3401_0_0000000_0
        : cip13 is > 3400_0_0000000_0 and < 3500_0_0000000_0;

    /// <summary>
    /// Validates the syntax for a given CIP7, a package's unique identifier.
    /// </summary>
    /// <remarks>
    /// The CIP7 / UCD7 is a 7-digit subset of the CIP13, ending at the second-last digit of the latter.
    /// </remarks>
    /// <param name="cip7">The CIP7 to validate.</param>
    /// <returns><see langword="true"/> if the CIP7 is valid; otherwise, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsValidCip7(this int cip7) => cip7 is > 0 and < 10000000;
    
    /// <summary>
    /// Validates the syntax for a given CIS, a product's unique identifier.
    /// </summary>
    /// <remarks>
    /// The CIS is a 8-digit number.
    /// </remarks>
    /// <param name="cis">The CIS to validate.</param>
    /// <returns><see langword="true"/> if the CIS is valid; otherwise, <see langword="false"/>.</returns>
    [Pure]
    public static bool IsValidCis(this int cis) => cis is > 0 and < 100000000;
}