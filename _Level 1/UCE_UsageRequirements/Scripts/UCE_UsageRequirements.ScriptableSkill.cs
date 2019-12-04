// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

public abstract partial class ScriptableSkill
{
    [Header("-=-=- UCE USAGE REQUIREMENTS -=-=-")]
    public UCE_Requirements usageRequirements;

    [Tooltip("Can only be used while a item of the same ID is equipped (0 = disabled)")]
    public int usageEquipmentId;

    [Tooltip("Can only be used while the player is inside a usage area of the same ID (0 = disabled)")]
    public int usageAreaId;

#if _iMMOPRESTIGECLASSES

    [Header("-=-=- UCE Prestige Classes -=-=-")]
    [Tooltip("Can only be learned/upgraded by one of those prestige classes")]
    public UCE_PrestigeClassTemplate[] learnablePrestigeClasses;

#endif

    // -----------------------------------------------------------------------------------
    // UCE_CanCast
    // -----------------------------------------------------------------------------------
    public bool UCE_CanCast(Entity caster, int skillLevel)
    {
        if (caster is Player)
        {
            return (usageAreaId <= 0 || ((Player)caster).UCE_usageAreaId == usageAreaId) &&
                    (usageEquipmentId <= 0 || ((Player)caster).UCE_GetEquipmentId(usageEquipmentId)) &&
                    usageRequirements.checkRequirements((Player)caster)
                    ;
        }

        return true;
    }

    // -----------------------------------------------------------------------------------
}
